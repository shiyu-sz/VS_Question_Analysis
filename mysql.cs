
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Question_Analysis
{
    public partial class Form1
    {
        //查询库是否存在
        private bool Is_Database_Exists(string ip, string port, string user, string password, string database )
        {
            //string connect_str = "Server=172.93.40.38;port=3306;User ID=root;Password=password;CharSet=gbk;";
            string connect_str = "Server="+ip+";port="+port+";User ID="+user+";Password="+password+";CharSet=gbk;";
            string query_str = "SELECT * FROM information_schema.SCHEMATA where SCHEMA_NAME='"+database+"';";
            MySqlConnection myCon = new MySqlConnection(connect_str);//实例化链接
            myCon.Open();//开启连接
            MySqlCommand myCmd = new MySqlCommand(query_str, myCon);
            int n = myCmd.ExecuteNonQuery();
            MySqlDataReader reader = myCmd.ExecuteReader();

            if (reader.Read())
            {
                object name = reader.GetString(1);//GetString(1)得到表中第一列的值，用name接收，因为查的是*，所以就和表中的列数一样。
                if (name.ToString() == database)
                    //Console.WriteLine("数据库存在");
                    return true;
                else
                    //Console.WriteLine("数据库不存在");
                    return false;
            }
            else 
            {
                //Console.WriteLine("数据库不存在");
                return false;
            }
        }

        //查询库中的表是否存在
        private bool Is_Table_Exists(string ip, string port, string user, string password, string database, string table)
        {
            string connect_str = "Server="+ip+";port="+port+";User ID="+user+";Password="+password+";CharSet=gbk;";
            string query_str = "select table_name from information_schema.tables where table_schema='"+database+"';";
            MySqlConnection myCon = new MySqlConnection(connect_str);//实例化链接
            myCon.Open();//开启连接
            MySqlCommand myCmd = new MySqlCommand(query_str, myCon);
            int n = myCmd.ExecuteNonQuery();
            MySqlDataReader reader = myCmd.ExecuteReader();
            
            while (reader.Read())
            {
                object name = reader.GetString(0);//GetString(1)得到表中第一列的值，用name接收，因为查的是*，所以就和表中的列数一样。
                //Console.WriteLine("table = {0}", name.ToString());
                if (name.ToString() == table)
                {
                    //Console.WriteLine("表存在");
                    return true;
                }
            }
            //Console.WriteLine("表不存在");
            return false;
        }

        //创建库
        private bool Create_Databse(string ip, string port, string user, string password, string database)
        {
            if (Is_Database_Exists(ip, port, user, password, database) == true)
            {
                Console.WriteLine("{0}数据库存在", database);
                return false;
            }
            else 
            {
                string connect_str = "Server=" + ip + ";port=" + port + ";User ID=" + user + ";Password=" + password + ";CharSet=gbk;";
                string create_database = "CREATE DATABASE " + database + ";";
                MySqlConnection conn = new MySqlConnection(connect_str);
                MySqlCommand cmd = new MySqlCommand(create_database, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        //创建表
        private bool Create_Table(string ip, string port, string user, string password, string database, string table, string structure)
        {
            if (Is_Table_Exists(ip, port, user, password, database, table) == true)
            {
                Console.WriteLine("{0}库中的{1}表存在", database, table);
                return false;
            }
            else
            {
                string connect_str = "Server=" + ip + ";port=" + port + ";User ID=" + user + ";Password=" + password + ";Database=" + database + ";CharSet=gbk;";
                string createStatement = "CREATE TABLE " + table + structure;

                using (MySqlConnection conn = new MySqlConnection(connect_str))
                {
                    conn.Open();
                    // 建表  
                    using (MySqlCommand cmd = new MySqlCommand(createStatement, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("{0}库中的{1}表创建成功！", database, table);
                return true;
            }
        }

        //删除库
        private bool Delete_Databse(string ip, string port, string user, string password, string database)
        {
            if (Is_Database_Exists(ip, port, user, password, database) == true)
            {
                string connect_str = "Server=" + ip + ";port=" + port + ";User ID=" + user + ";Password=" + password + ";CharSet=gbk;";
                string create_database = "DROP DATABASE " + database + ";";
                MySqlConnection conn = new MySqlConnection(connect_str);
                MySqlCommand cmd = new MySqlCommand(create_database, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                if (Is_Database_Exists(ip, port, user, password, database) == false)
                {
                    Console.WriteLine("{0}数据库已删除", database);
                    return true;
                }
                else
                {
                    Console.WriteLine("{0}数据库删除失败", database);
                    return false; 
                }
            }
            else
            {
                Console.WriteLine("{0}数据库不存在", database);
                return false;
            }
        }

        //删除表
        private bool Delete_Table(string ip, string port, string user, string password, string database, string table)
        {
            if (Is_Table_Exists(ip, port, user, password, database, table) == true)
            {
                string connect_str = "Server=" + ip + ";port=" + port + ";User ID=" + user + ";Password=" + password + ";Database=" + database + ";CharSet=gbk;";
                string createStatement = "DROP TABLE " + table;

                using (MySqlConnection conn = new MySqlConnection(connect_str))
                {
                    conn.Open();
                    // 删除表  
                    using (MySqlCommand cmd = new MySqlCommand(createStatement, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                if (Is_Table_Exists(ip, port, user, password, database, table) == false)
                {
                    Console.WriteLine("{0}库中的{1}表已删除", database, table);
                    return true;
                }
                else
                {
                    Console.WriteLine("{0}库中的{1}表删除失败", database, table);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("{0}库中的{1}表不存在！", database, table);
                return false;
            }
        }

        //插入一行数据
        private bool Insert_Table(string ip, string port, string user, string password, string database, string table)
        { 
            
        }
    }
}