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
            //Is_Database_Exists("172.93.40.38", "3306", "root", "password", "mydb1");
            //Is_Table_Exists("172.93.40.38", "3306", "root", "password", "mydb", "table2");
            /*
            if(Create_Databse("172.93.40.38", "3306", "root", "password", "mydb1") == true)
                Console.WriteLine("数据库创建成功！");
            else
                Console.WriteLine("数据库创建失败！");

            if (Create_Table("172.93.40.38", "3306", "root", "password", "mydb1", "table1", "(name VARCHAR(20),age int, sex CHAR(1))") == true)
                Console.WriteLine("表创建成功！");
            else
                Console.WriteLine("表创建失败！");
             */
             /*
             if(Delete_Databse("172.93.40.38", "3306", "root", "password", "mydb1") == true)
                 Console.WriteLine("数据库删除成功！");
             else
                 Console.WriteLine("数据库删除失败！");
              */
            if (Delete_Table("172.93.40.38", "3306", "root", "password", "test2", "table1") == true)
                 Console.WriteLine("数据库删除成功！");
             else
                 Console.WriteLine("数据库删除失败！");
        }


    }
}
