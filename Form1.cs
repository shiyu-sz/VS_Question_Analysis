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
            string str = "Server=127.0.0.1;User ID=root;Password=84436446;Database=mydb;CharSet=gbk;";

            MySqlConnection con = new MySqlConnection(str);//实例化链接

            con.Open();//开启连接

            string strcmd = "select * from tabel1";

            MySqlCommand cmd = new MySqlCommand(strcmd, con);

            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            ada.Fill(ds);//查询结果填充数据集

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();//关闭连接
        }
    }
}
