﻿
using System.IO;
using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Question_Analysis
{
    public partial class Form1
    {
        int temp = 0;
        int Line_Count = 0;
        int Subject_Count = 1;
        bool error_flag = false;
        MySqlConnection sqlcom = null;
        public void MyThread()
        {
            while (_shouldStop)
            {
                switch (common.gCurrent_cmd)
                {
                    case e_Current_cmd.CHECK_INPUT:
                    {
                        if (File.Exists(common.gInput_Info.input_path))
                        {
                            Console.WriteLine("文件存在！");
                        }
                        else
                        {
                            BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "题库文件不存在" });
                            common.gCurrent_cmd = e_Current_cmd.CONVERSION_FINISH;
                            break;
                        }

                        //连接接据库
                        temp = Connect_Databse(ref sqlcom, common.gInput_Info.mysql_ip, common.gInput_Info.mysql_port, common.gInput_Info.mysql_ID, common.gInput_Info.mysql_password);
                        if (temp == 0x00)
                        {
                            temp = Is_Database_Exists(sqlcom, common.gInput_Info.mysql_databases);
                            if (temp == 0x00)
                            {
                                Console.WriteLine("数据库存在!");
                                string str_info = "警告：名称为" + common.gInput_Info.mysql_databases + "的库已经存在！";
                                BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { str_info });
                            }
                            else if (temp == 0x01)
                            {
                                Console.WriteLine("数据库不存在!");
                                temp = Create_Databse(sqlcom, common.gInput_Info.mysql_databases);
                                if (temp == 0x00)
                                {
                                    Console.WriteLine("创建库成功!");
                                    temp = User_Databse(sqlcom, common.gInput_Info.mysql_databases);
                                    if (temp == 0x00)
                                    {
                                        temp = Create_Table(sqlcom, common.gInput_Info.mysql_table, common.gInput_Info.table_struct);
                                        if (temp == 0x00)
                                        {
                                            Console.WriteLine("创建表成功!");
                                            common.gCurrent_cmd = e_Current_cmd.START_CONVERSION;
                                            common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("创建表失败!");
                                            BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "创建表失败!" });
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("使用库失败!");
                                        BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "使用库失败!" });
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("创建库失败!");
                                    BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "创建库失败!" });
                                }
                            }
                            else
                            {
                                Console.WriteLine("查询库错误!");
                                BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "查询库错误!" });
                            }
                        }
                        else
                        {
                            Console.WriteLine("连接数据库失败!");
                            BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "连接数据库失败!" });
                        }

                        temp = Connect_Databse(sqlcom);
                        if (temp == 0x00)
                        {
                            Console.WriteLine("数据库关闭成功!");
                        }
                        else
                        {
                            Console.WriteLine("数据库关闭失败!");
                        }
                        common.gCurrent_cmd = e_Current_cmd.CONVERSION_FINISH;
                        break;
                    }
                    case e_Current_cmd.START_CONVERSION:
                    {
                        FileStream fs = new FileStream(common.gInput_Info.input_path, FileMode.Open, FileAccess.Read);
                        StreamReader read = new StreamReader(fs);
                        string line;
                        while (((line = read.ReadLine()) != null) && (error_flag == false))
                        {
                            Line_Count++;
                            Console.WriteLine(line.ToString());
                            switch (common.gConversion_cmd)
                            {
                                case e_Conversion_cmd.SUBJECT:
                                {
                                    string num = line.Substring(0, 3);
                                    if (int.Parse(num) != Subject_Count)
                                    {
                                        string error = "题号错误：" + Line_Count.ToString();
                                        BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { error });
                                        error_flag = true;
                                        break;
                                    }
                                    common.gTest_Questions.Subject = line.Substring(4, line.Length - 4);
                                    break;
                                }
                            }

                            if (error_flag == true)
                            {
                                common.gCurrent_cmd = e_Current_cmd.CONVERSION_FAILURE;
                                break;
                            }
                        }

                        Thread.Sleep(1);
                        break;
                    }
                    case e_Current_cmd.CONVERSION_FINISH:
                    {
                        Console.WriteLine("转换完成！");
                        BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "转换完成！" });
                        this.RequestStop();
                        workerThread.Join();
                        break;
                    }
                    case e_Current_cmd.CONVERSION_FAILURE:
                    {
                        this.RequestStop();
                        workerThread.Join();
                        break; 
                    }
                    default: break; 
                }
                Thread.Sleep(1);
            }
        }
        public void RequestStop()
        {
            _shouldStop = false;
        }

        public void RequestStart()
        {
            _shouldStop = true;
        }
        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        private volatile bool _shouldStop;

    }
}