namespace Question_Analysis
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_txtpath = new System.Windows.Forms.TextBox();
            this.button_open = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_mysqlIP = new System.Windows.Forms.TextBox();
            this.label_mysqlPort = new System.Windows.Forms.Label();
            this.textBox_mysqlPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_mysqlID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_mysqlPasswd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_mysqlDatabease = new System.Windows.Forms.TextBox();
            this.textBox_mysqlTable = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "TXT题库路径";
            // 
            // textBox_txtpath
            // 
            this.textBox_txtpath.Location = new System.Drawing.Point(15, 40);
            this.textBox_txtpath.Name = "textBox_txtpath";
            this.textBox_txtpath.Size = new System.Drawing.Size(350, 21);
            this.textBox_txtpath.TabIndex = 1;
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(380, 40);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 4;
            this.button_open.Text = "打开";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(20, 205);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 6;
            this.button_start.Text = "开始分析";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(20, 245);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 7;
            this.button_stop.Text = "停止分析";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 300);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(450, 220);
            this.dataGridView1.TabIndex = 9;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(200, 530);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "mysql IP : ";
            // 
            // textBox_mysqlIP
            // 
            this.textBox_mysqlIP.Location = new System.Drawing.Point(105, 108);
            this.textBox_mysqlIP.Name = "textBox_mysqlIP";
            this.textBox_mysqlIP.Size = new System.Drawing.Size(120, 21);
            this.textBox_mysqlIP.TabIndex = 13;
            // 
            // label_mysqlPort
            // 
            this.label_mysqlPort.AutoSize = true;
            this.label_mysqlPort.Location = new System.Drawing.Point(235, 108);
            this.label_mysqlPort.Name = "label_mysqlPort";
            this.label_mysqlPort.Size = new System.Drawing.Size(83, 12);
            this.label_mysqlPort.TabIndex = 14;
            this.label_mysqlPort.Text = "mysql port : ";
            // 
            // textBox_mysqlPort
            // 
            this.textBox_mysqlPort.Location = new System.Drawing.Point(322, 108);
            this.textBox_mysqlPort.Name = "textBox_mysqlPort";
            this.textBox_mysqlPort.Size = new System.Drawing.Size(120, 21);
            this.textBox_mysqlPort.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "ID : ";
            // 
            // textBox_mysqlID
            // 
            this.textBox_mysqlID.Location = new System.Drawing.Point(105, 135);
            this.textBox_mysqlID.Name = "textBox_mysqlID";
            this.textBox_mysqlID.Size = new System.Drawing.Size(120, 21);
            this.textBox_mysqlID.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "password : ";
            // 
            // textBox_mysqlPasswd
            // 
            this.textBox_mysqlPasswd.Location = new System.Drawing.Point(322, 135);
            this.textBox_mysqlPasswd.Name = "textBox_mysqlPasswd";
            this.textBox_mysqlPasswd.Size = new System.Drawing.Size(120, 21);
            this.textBox_mysqlPasswd.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "databases : ";
            // 
            // textBox_mysqlDatabease
            // 
            this.textBox_mysqlDatabease.Location = new System.Drawing.Point(105, 162);
            this.textBox_mysqlDatabease.Name = "textBox_mysqlDatabease";
            this.textBox_mysqlDatabease.Size = new System.Drawing.Size(120, 21);
            this.textBox_mysqlDatabease.TabIndex = 21;
            // 
            // textBox_mysqlTable
            // 
            this.textBox_mysqlTable.Location = new System.Drawing.Point(322, 162);
            this.textBox_mysqlTable.Name = "textBox_mysqlTable";
            this.textBox_mysqlTable.Size = new System.Drawing.Size(120, 21);
            this.textBox_mysqlTable.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "table : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(17, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 24;
            this.label9.Text = "Mysql登入";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(112, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = " ";
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(114, 210);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(47, 12);
            this.label_info.TabIndex = 26;
            this.label_info.Text = "label11";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_mysqlTable);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_mysqlDatabease);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_mysqlPasswd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_mysqlID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_mysqlPort);
            this.Controls.Add(this.label_mysqlPort);
            this.Controls.Add(this.textBox_mysqlIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.textBox_txtpath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_txtpath;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_mysqlIP;
        private System.Windows.Forms.Label label_mysqlPort;
        private System.Windows.Forms.TextBox textBox_mysqlPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_mysqlID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_mysqlPasswd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_mysqlDatabease;
        private System.Windows.Forms.TextBox textBox_mysqlTable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_info;
    }
}

