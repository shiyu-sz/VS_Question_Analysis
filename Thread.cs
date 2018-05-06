
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
        int Subject_Count = 0;
        MySqlConnection sqlcom = null;
        public void MyThread()
        {
            while (_shouldStop)
            {
                switch (common.gCurrent_cmd)
                {
                    case e_Current_cmd.CHECK_INPUT:
                    {
                        Console.WriteLine("e_Current_cmd.CHECK_INPUT!");
                        if (File.Exists(common.gInput_Info.input_path))
                        {
                            Console.WriteLine("文件存在！");
                        }
                        else
                        {
                            BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "题库文件不存在" });
                            common.gCurrent_cmd = e_Current_cmd.CONVERSION_FAILURE;
                            break;
                        }

                        //连接接据库
                        temp = common_mysql.Connect_Databse(ref sqlcom, common.gInput_Info.mysql_ip, common.gInput_Info.mysql_port, common.gInput_Info.mysql_ID, common.gInput_Info.mysql_password);
                        if (temp == 0x00)
                        {
                            temp = common_mysql.Is_Database_Exists(sqlcom, common.gInput_Info.mysql_databases);
                            if (temp == 0x00)
                            {
                                Console.WriteLine("数据库存在!");
                                //Change_Datebase_Code(sqlcom, common.gInput_Info.mysql_databases);
                                temp = common_mysql.User_Databse(sqlcom, common.gInput_Info.mysql_databases);
                                if (temp == 0x00)
                                {
                                    temp = common_mysql.Is_Table_Exists(sqlcom, common.gInput_Info.mysql_databases, common.gInput_Info.mysql_table);
                                    if (temp == 0x00)
                                    {
                                        Console.WriteLine("数据表存在!");
                                        BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "表已存在!" });
                                    }
                                    else
                                    {
                                        temp = common_mysql.Create_Table(sqlcom, common.gInput_Info.mysql_table, common.gInput_Info.table_struct);
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
                                }
                                else
                                {
                                    Console.WriteLine("使用库失败!");
                                    BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "使用库失败!" });
                                }
                                //string str_info = "警告：名称为" + common.gInput_Info.mysql_databases + "的库已经存在！";
                                //BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { str_info });
                            }
                            else if (temp == 0x01)
                            {
                                Console.WriteLine("数据库不存在!");
                                temp = common_mysql.Create_Databse(sqlcom, common.gInput_Info.mysql_databases);
                                if (temp == 0x00)
                                {
                                    Console.WriteLine("创建库成功!");
                                    //Change_Datebase_Code(sqlcom, common.gInput_Info.mysql_databases);
                                    temp = common_mysql.User_Databse(sqlcom, common.gInput_Info.mysql_databases);
                                    if (temp == 0x00)
                                    {
                                        temp = common_mysql.Create_Table(sqlcom, common.gInput_Info.mysql_table, common.gInput_Info.table_struct);
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

                        temp = common_mysql.Close_Databse(sqlcom);
                        if (temp == 0x00)
                        {
                            Console.WriteLine("数据库关闭成功!");
                        }
                        else
                        {
                            Console.WriteLine("数据库关闭失败!");
                            BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "数据库关闭失败!" });
                        }
                        common.gCurrent_cmd = e_Current_cmd.CONVERSION_FAILURE;
                        break;
                    }
                    case e_Current_cmd.START_CONVERSION:
                    {
                        Console.WriteLine("e_Current_cmd.START_CONVERSION!");
                        System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
                        FileStream fs = new FileStream(common.gInput_Info.input_path, FileMode.Open, FileAccess.Read);
                        StreamReader read = new StreamReader(fs);
                        string line;
                        while (((line = read.ReadLine()) != null) && (_shouldStop != false))
                        {
                            Line_Count++;
                            Console.WriteLine("Line_Count = {0} line = {1}", Line_Count, line);
                            switch (common.gConversion_cmd)
                            {
                                case e_Conversion_cmd.SUBJECT:
                                {
                                    //Console.WriteLine("e_Conversion_cmd.SUBJECT!");
                                    try
                                    {
                                        if ((line.Length > 4))
                                        {
                                            if (reg1.IsMatch(line.Substring(0, 3)))
                                            {
                                                common.gTest_Questions.Subject = line.Substring(4);
                                                common.gConversion_cmd = e_Conversion_cmd.OPTION_A;
                                            }
                                            else
                                            {
                                                Console.WriteLine("SUBJECT:错误的行,不是题目!");
                                                Console.WriteLine("Line_Count = {0}", Line_Count);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("SUBJECT:错误的行!");
                                            Console.WriteLine("Line_Count = {0}", Line_Count);
                                        }
                                    }
                                    catch
                                    {
                                        common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                        Console.WriteLine("SUBJECT:不完整的题目或错误的行!");
                                        Console.WriteLine("Line_Count = {0}", Line_Count);
                                    }
                                    break;
                                }
                                case e_Conversion_cmd.OPTION_A:
                                {
                                    //Console.WriteLine("e_Conversion_cmd.OPTION_A!");
                                    try
                                    {
                                        if (line.Substring(0, 1) == "A")
                                        {
                                            common.gTest_Questions.Option_A = line.Substring(2);
                                            common.gConversion_cmd = e_Conversion_cmd.OPTION_B;
                                        }
                                        else
                                        {
                                            common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                            Console.WriteLine("OPTION_A:错误的行,没有读到A!");
                                            Console.WriteLine("Line_Count = {0}", Line_Count);
                                        }
                                    }
                                    catch
                                    {
                                        common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                        Console.WriteLine("OPTION_A:不完整的题目或错误的行!");
                                        Console.WriteLine("Line_Count = {0}", Line_Count);
                                    }
                                    break;
                                }
                                case e_Conversion_cmd.OPTION_B:
                                {
                                    //Console.WriteLine("e_Conversion_cmd.OPTION_B!");
                                    try
                                    {
                                        if (line.Substring(0, 1) == "B")
                                        {
                                            common.gTest_Questions.Option_B = line.Substring(2);
                                            common.gConversion_cmd = e_Conversion_cmd.OPTION_C;
                                        }
                                        else
                                        {
                                            common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                            Console.WriteLine("OPTION_B:错误的行,没有读到B!");
                                            Console.WriteLine("Line_Count = {0}", Line_Count);
                                        }
                                    }
                                    catch
                                    {
                                        common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                        Console.WriteLine("OPTION_B:不完整的题目或错误的行!");
                                        Console.WriteLine("Line_Count = {0}", Line_Count);
                                    }
                                    break;
                                }
                                case e_Conversion_cmd.OPTION_C:
                                {
                                    //Console.WriteLine("e_Conversion_cmd.OPTION_C!");
                                    try
                                    {
                                        if (line.Substring(0, 1) == "C")
                                        {
                                            common.gTest_Questions.Option_C = line.Substring(2);
                                            common.gConversion_cmd = e_Conversion_cmd.ANSWER;
                                        }
                                        else
                                        {
                                            common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                            Console.WriteLine("OPTION_C:错误的行,没有读到C!");
                                            Console.WriteLine("Line_Count = {0}", Line_Count);
                                        }
                                    }
                                    catch
                                    {
                                        common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                        Console.WriteLine("OPTION_C:不完整的题目或错误的行!");
                                        Console.WriteLine("Line_Count = {0}", Line_Count);
                                    }
                                    break;
                                }
                                case e_Conversion_cmd.ANSWER:
                                {
                                    //Console.WriteLine("e_Conversion_cmd.ANSWER!");
                                    try
                                    {
                                        if (line.Substring(0, 2) == "答案")
                                        {
                                            common.gTest_Questions.Answer = line.Substring(3,1);
                                            common.gConversion_cmd = e_Conversion_cmd.NULL;
                                        }
                                        else
                                        {
                                            common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                            Console.WriteLine("OPTION_C:错误的行,没有读到答案!");
                                            Console.WriteLine("Line_Count = {0}", Line_Count);
                                        }
                                    }
                                    catch
                                    {
                                        common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                        Console.WriteLine("OPTION_C:不完整的题目或错误的行!");
                                        Console.WriteLine("Line_Count = {0}", Line_Count);
                                    }
                                    break;
                                }
                                case e_Conversion_cmd.NULL:
                                {
                                    //Console.WriteLine("e_Conversion_cmd.NULL!");
                                    try
                                    {
                                        if (line == "")
                                        {
                                            common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                            common.gTest_Questions.Title_Number = Subject_Count;
                                            common_mysql.Insert_Table(sqlcom, common.gInput_Info.mysql_table, common.gTest_Questions);
                                            Subject_Count++;
                                        }
                                        else
                                        {
                                            common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                            Console.WriteLine("NULL:错误的行,没有读到空的行!");
                                            Console.WriteLine("Line_Count = {0}", Line_Count);
                                        }
                                    }
                                    catch
                                    {
                                        common.gConversion_cmd = e_Conversion_cmd.SUBJECT;
                                        Console.WriteLine("NULL:不完整的题目或错误的行!");
                                        Console.WriteLine("Line_Count = {0}", Line_Count);
                                    }
                                    break;
                                }
                                default: break;
                            }
                        }
                        common.gCurrent_cmd = e_Current_cmd.CONVERSION_FINISH;
                        Thread.Sleep(100);
                        break;
                    }
                    case e_Current_cmd.CONVERSION_FINISH:
                    {
                        Thread.Sleep(100);
                        Console.WriteLine("转换完成！");
                        BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "转换完成！" });
                        this.RequestStop();
                        //关闭数据库
                        temp = common_mysql.Close_Databse(sqlcom);
                        if (temp == 0x00)
                        {
                            Console.WriteLine("数据库关闭成功!");
                        }
                        else
                        {
                            Console.WriteLine("数据库关闭失败!");
                        }

                        break;
                    }
                    case e_Current_cmd.CONVERSION_FAILURE:
                    {
                        Console.WriteLine("转换失败！");
                        BeginInvoke(new stuInfoDelegate(showStuIfo), new object[] { "转换失败！" });
                        this.RequestStop();

                        //关闭数据库
                        temp = common_mysql.Close_Databse(sqlcom);
                        if (temp == 0x00)
                        {
                            Console.WriteLine("数据库关闭成功!");
                        }
                        else
                        {
                            Console.WriteLine("数据库关闭失败!");
                        }

                        break; 
                    }
                    default: break; 
                }
                Thread.Sleep(1);
            }
            //关闭数据库
            temp = common_mysql.Close_Databse(sqlcom);
            if (temp == 0x00)
            {
                Console.WriteLine("数据库关闭成功!");
            }
            else
            {
                Console.WriteLine("数据库关闭失败!");
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