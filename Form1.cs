using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading;

namespace Question_Analysis
{
    public partial class Form1 : Form
    {
        Thread workerThread = null;
        public delegate void stuInfoDelegate(string str);  //声明委托类型

        public Form1()
        {
            InitializeComponent();

            this.textBox_mysqlIP.Text           = "127.0.0.1";
            this.textBox_mysqlPort.Text         = "3306";
            this.textBox_mysqlID.Text           = "root";
            this.textBox_mysqlPasswd.Text       = "84436446";
            this.textBox_mysqlDatabease.Text    = "sy_test";
            this.textBox_mysqlTable.Text        = "table1";

            common.gInput_Info.input_path = "E:\\GitHub\\VS_Question_Analysis\\无人机驾驶员试题库50.txt";
            this.textBox_txtpath.Text = common.gInput_Info.input_path;

        }

        //委托，用于在线程中防问UI线程的控件
        private void showStuIfo(string str)  //本例中的线程要通过这个方法来访问主线程中的控件
        {
            this.label_info.Text = str;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int temp;
            MySqlConnection sqlcom = null;
            /*
            //连接接据库
            temp = Connect_Databse(ref sqlcom, "172.93.40.38", "3306", "root", "password");
            if (temp == 0x00)
            {
                temp = Is_Database_Exists(sqlcom, "mydb");
                if (temp == 0x00)
                {
                    Console.WriteLine("数据库存在!");
                    temp = Is_Table_Exists(sqlcom, "mydb", "table4");
                    if(temp == 0x00)
                        Console.WriteLine("表存在!");
                    else if(temp == 0x01)
                        Console.WriteLine("表不存在!");
                    else
                        Console.WriteLine("查询表错误");
                }
                else if (temp == 0x01)
                {
                    Console.WriteLine("数据库不存在!");
                }
                else
                {
                    Console.WriteLine("查询库错误!");
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
            }
            else
                Console.WriteLine("连接数据库失败!");
        }
             * */

            //连接接据库
            temp = Connect_Databse(ref sqlcom, "172.93.40.38", "3306", "root", "password");
            if (temp == 0x00)
            {
                temp = Is_Database_Exists(sqlcom, "test2");
                if (temp == 0x00)
                {
                    Console.WriteLine("数据库存在!");
                    /*
                    temp = Delete_Databse(sqlcom, "mydb2");
                    if(temp == 0x00)
                        Console.WriteLine("删除成功!");
                    else
                        Console.WriteLine("删除失败!");
                     * */
                    temp = User_Databse(sqlcom, "test2");
                    if (temp == 0x00)
                    {
                        temp = Is_Table_Exists(sqlcom, "test2", "table3");
                        if (temp == 0x00)
                        {
                            temp = Delete_Table(sqlcom, "table3");
                            if (temp == 0x00)
                                Console.WriteLine("删除成功!");
                            else
                                Console.WriteLine("删除失败!");
                        }
                        else if (temp == 0x01)
                        {
                            Console.WriteLine("表不存在!");
                        }
                        else
                            Console.WriteLine("查询错误!");
                    }
                    else
                        Console.WriteLine("使用数据库失败!");
                }
                else if (temp == 0x01)
                {
                    Console.WriteLine("数据库不存在!");
                    temp = Create_Databse(sqlcom, "mydb2");
                    if (temp == 0x00)
                    {
                        Console.WriteLine("创建库成功!");
                        temp = User_Databse(sqlcom, "mydb2");
                        if (temp == 0x00)
                        {
                            temp = Is_Table_Exists(sqlcom, "mydb2", "mytable5");
                            if(temp == 0x00)
                                Console.WriteLine("表已经存在!");
                            else if (temp == 0x01)
                            {
                                temp = Create_Table(sqlcom, "mytable5", "(s1 VARCHAR(20), s2 INT, s3 INT)");
                                if (temp == 0x00)
                                    Console.WriteLine("创建表成功!");
                                else
                                    Console.WriteLine("创建表失败!");
                            }
                            else
                                Console.WriteLine("查询错误!");
                        }
                        else
                            Console.WriteLine("使用库失败!");
                    }
                    else
                        Console.WriteLine("创建库失败!");
                }
                else
                {
                    Console.WriteLine("查询库错误!");
                }

                temp = Close_Databse(sqlcom);
                if (temp == 0x00)
                {
                    Console.WriteLine("数据库关闭成功!");
                }
                else
                {
                    Console.WriteLine("数据库关闭失败!");
                }
            }
            else
                Console.WriteLine("连接数据库失败!");
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                common.gInput_Info.input_path = file.FileName;
                this.textBox_txtpath.Text = common.gInput_Info.input_path;
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {

            common.gInput_Info.mysql_ip         = this.textBox_mysqlIP.Text;
            common.gInput_Info.mysql_port       = this.textBox_mysqlPort.Text;
            common.gInput_Info.mysql_ID         = this.textBox_mysqlID.Text;
            common.gInput_Info.mysql_password   = this.textBox_mysqlPasswd.Text;
            common.gInput_Info.mysql_databases  = this.textBox_mysqlDatabease.Text;
            common.gInput_Info.mysql_table      = this.textBox_mysqlTable.Text;
            common.gInput_Info.table_struct     = "(Subject VARCHAR(200), A VARCHAR(100), B VARCHAR(100), C VARCHAR(1000), Answer CHAR(1))";

            workerThread = new Thread(MyThread);
            workerThread.Name = "文件处理线程";
            common.gCurrent_cmd = e_Current_cmd.CHECK_INPUT;
            RequestStart();
            workerThread.Start();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            RequestStop();
            workerThread.Join();
            Console.WriteLine("thread stop!");
        }

    }
}
