
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Question_Analysis
{
    public partial class Form1
    {

        //连接数据库
        //返回值：0x00>连接正常 -1>连接失败
        private int Connect_Databse(ref MySqlConnection con, string ip, string port, string user, string password)
        {
            string connect_str = "Server=" + ip + ";port=" + port + ";User ID=" + user + ";Password=" + password + ";CharSet=utf8;";

            try
            {
                con = new MySqlConnection(connect_str);//实例化链接
                con.Open();//开启连接
                return 0x00;
            }
            catch (Exception ex)
            {
                Console.WriteLine("连接数据库错误:{0}!", ex.ToString());
                return -1;
            }
        }

        //插入一行数据
        //返回值：0x00>插入成功 -1>插入失败
        private int Insert_Table(MySqlConnection con, string table, Test_Questions data)
        {
            string insert_str = "INSERT INTO " + table + " VALUES ( "+ "\"" + data.Subject + "\""+", " + "\""+ data.Option_A + "\""+ ", " + "\""+ data.Option_B + "\""+ ", " + "\""+ data.Option_C + "\""+ ", " + "\""+ data.Answer + "\""+ " );";
            Console.WriteLine("INSERT = {0}", insert_str);

            try
            {
                MySqlCommand cmd = new MySqlCommand(insert_str, con);
                cmd.ExecuteNonQuery();
                return 0x00;
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入数据失败!{0}", ex.ToString());
                return -1;
            }
        }

        //关闭数据库
        //返回值：0x00>关闭成功 -1>关闭失败
        private int Connect_Databse(MySqlConnection com)
        {
            try
            {
                com.Close();
                return 0x00;
            }
            catch (Exception ex)
            {
                Console.WriteLine("关闭数据库失败!{0}", ex.ToString());
                return -1;
            }
        }

        //查询库是否存在
        //返回值：0x00>数据库存在 0x01>数据库不存在 -1>查询数据库错误
        private int Is_Database_Exists(MySqlConnection com, string database)
        {
            string query_str = "SELECT * FROM information_schema.SCHEMATA where SCHEMA_NAME='"+database+"';";

            try
            {
                MySqlCommand myCmd = new MySqlCommand(query_str, com);
                int n = myCmd.ExecuteNonQuery();
                MySqlDataReader reader = myCmd.ExecuteReader();

                if (reader.Read())
                {
                    object name = reader.GetString(1);//GetString(1)得到表中第一列的值，用name接收，因为查的是*，所以就和表中的列数一样。
                    reader.Close();
                    if (name.ToString() == database)
                        //Console.WriteLine("数据库存在");
                        return 0x00;
                    else
                        //Console.WriteLine("数据库不存在");
                        return 0x01;
                }
                else
                {
                    //Console.WriteLine("数据库不存在");
                    reader.Close();
                    return 0x01;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询数据库错误:{0}!", ex.ToString());
                return -1;
            } 
        }

        //查询库中的表是否存在
        //返回值：0x00>表存在 0x01>表不存在 -1>查询数据库错误
        private int Is_Table_Exists(MySqlConnection com, string database, string table)
        {
            string query_str = "select table_name from information_schema.tables where table_schema='"+database+"';";

            try
            {
                MySqlCommand myCmd = new MySqlCommand(query_str, com);
                int n = myCmd.ExecuteNonQuery();
                MySqlDataReader reader = myCmd.ExecuteReader();
                while (reader.Read())
                {
                    object name = reader.GetString(0);//GetString(1)得到表中第一列的值，用name接收，因为查的是*，所以就和表中的列数一样。
                    //Console.WriteLine("table = {0}", name.ToString());
                    if (name.ToString() == table)
                    {
                        //Console.WriteLine("表存在");
                        reader.Close();
                        return 0x00;
                    }
                }
                reader.Close();
                //Console.WriteLine("表不存在");
                return 0x01;
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询库中的表错误:{0}!", ex.ToString());
                return -1;
            }
        }

        //创建库
        //返回值：0x00>创建成功  -1>数据库创建错误
        private int Create_Databse(MySqlConnection com, string database)
        {
            string create_database = "CREATE DATABASE " + database + ";";

            try
            {
                MySqlCommand cmd = new MySqlCommand(create_database, com);
                cmd.ExecuteNonQuery();
                return 0x00;
            }
            catch (Exception ex)
            {
                Console.WriteLine("创建数据库错误:{0}!", ex.ToString());
                return -1;
            }
        }

        //使用库
        //返回值：0x00>使用库成功  -1>使用库错误
        private int User_Databse(MySqlConnection com, string database)
        {
            string user_database = "USE " + database + ";";

            try
            {
                MySqlCommand cmd = new MySqlCommand(user_database, com);
                cmd.ExecuteNonQuery();
                return 0x00;
            }
            catch (Exception ex)
            {
                Console.WriteLine("使用数据库错误:{0}!", ex.ToString());
                return -1;
            }
        }

        //创建表
        //返回值：0x00>创建成功  -1>表创建错误
        private int Create_Table(MySqlConnection com, string table, string structure)
        {
            //string createStatement = "CREATE TABLE " + table + structure + "ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=1;";
            string createStatement = "CREATE TABLE " + table + structure;
            try
            {
                MySqlCommand cmd = new MySqlCommand(createStatement, com);
                cmd.ExecuteNonQuery();
                return 0x00;
            }
            catch (Exception ex)
            {
                Console.WriteLine("创建表错误:{0}!", ex.ToString());
                return -1;
            }
        }

        //删除库
        //返回值：0x00>删除库成功  -1>删除库错误
        private int Delete_Databse(MySqlConnection com, string database)
        {
            string create_database = "DROP DATABASE " + database + ";";
            try
            {
                MySqlCommand cmd = new MySqlCommand(create_database, com);
                cmd.ExecuteNonQuery();
                return 0x00;
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除库错误:{0}!", ex.ToString());
                return -1;
            }
        }

        //删除表
        //返回值：0x00>删除表成功  -1>删除表错误
        private int Delete_Table(MySqlConnection com, string table)
        {
            string createStatement = "DROP TABLE " + table;
            try
            {
                MySqlCommand cmd = new MySqlCommand(createStatement, com);
                cmd.ExecuteNonQuery();
                return 0x00;
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除表错误:{0}!", ex.ToString());
                return -1;
            }
        }

        //更改数据库编码
        private int Change_Datebase_Code(MySqlConnection com, string database)
        {
            string str = "alter database " + database + " character set utf8;";
            try
            {
                MySqlCommand cmd = new MySqlCommand(str, com);
                cmd.ExecuteNonQuery();
                return 0x00;
            }
            catch (Exception ex)
            {
                Console.WriteLine("更改数据库编码:{0}!", ex.ToString());
                return -1;
            }
        }
    }
}