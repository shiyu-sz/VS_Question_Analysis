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

namespace Question_Analysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = "Server=172.93.40.38;User ID=root;Password=password;Database=mydb;CharSet=gbk;";

            MySqlConnection con = new MySqlConnection(str);//实例化链接

            con.Open();//开启连接

            string strcmd = "select * from mytable";

            MySqlCommand cmd = new MySqlCommand(strcmd, con);

            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            ada.Fill(ds);//查询结果填充数据集

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();//关闭连接
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


    }
}
