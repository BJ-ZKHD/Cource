namespace SerialTool
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tB_Send = new System.Windows.Forms.TextBox();
            this.tB_Received = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_Connect = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_Clear = new System.Windows.Forms.Button();
            this.lb_RxCount = new System.Windows.Forms.Label();
            this.lb_TxCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cB_Baud = new System.Windows.Forms.ComboBox();
            this.bt_Connect = new System.Windows.Forms.Button();
            this.cB_Portname = new System.Windows.Forms.ComboBox();
            this.bt_Send = new System.Windows.Forms.Button();
            this.Serial = new System.IO.Ports.SerialPort(this.components);
            this.tim_Update = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tB_Send
            // 
            this.tB_Send.Location = new System.Drawing.Point(132, 367);
            this.tB_Send.Multiline = true;
            this.tB_Send.Name = "tB_Send";
            this.tB_Send.Size = new System.Drawing.Size(480, 48);
            this.tB_Send.TabIndex = 0;
            // 
            // tB_Received
            // 
            this.tB_Received.Location = new System.Drawing.Point(132, 12);
            this.tB_Received.Multiline = true;
            this.tB_Received.Name = "tB_Received";
            this.tB_Received.ReadOnly = true;
            this.tB_Received.Size = new System.Drawing.Size(579, 349);
            this.tB_Received.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_Connect);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.bt_Clear);
            this.groupBox1.Controls.Add(this.lb_RxCount);
            this.groupBox1.Controls.Add(this.lb_TxCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cB_Baud);
            this.groupBox1.Controls.Add(this.bt_Connect);
            this.groupBox1.Controls.Add(this.cB_Portname);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 403);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口配置";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lb_Connect
            // 
            this.lb_Connect.AutoSize = true;
            this.lb_Connect.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Connect.Location = new System.Drawing.Point(3, 322);
            this.lb_Connect.Name = "lb_Connect";
            this.lb_Connect.Size = new System.Drawing.Size(98, 18);
            this.lb_Connect.TabIndex = 10;
            this.lb_Connect.Text = "已断开连接";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(4, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "波特率选择：";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(4, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "串口选择：";
            // 
            // bt_Clear
            // 
            this.bt_Clear.Location = new System.Drawing.Point(0, 152);
            this.bt_Clear.Name = "bt_Clear";
            this.bt_Clear.Size = new System.Drawing.Size(120, 30);
            this.bt_Clear.TabIndex = 7;
            this.bt_Clear.Text = "清除";
            this.bt_Clear.UseVisualStyleBackColor = true;
            this.bt_Clear.Click += new System.EventHandler(this.bt_Clear_Click);
            // 
            // lb_RxCount
            // 
            this.lb_RxCount.AutoSize = true;
            this.lb_RxCount.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_RxCount.Location = new System.Drawing.Point(44, 380);
            this.lb_RxCount.Name = "lb_RxCount";
            this.lb_RxCount.Size = new System.Drawing.Size(62, 18);
            this.lb_RxCount.TabIndex = 6;
            this.lb_RxCount.Text = "label4";
            // 
            // lb_TxCount
            // 
            this.lb_TxCount.AutoSize = true;
            this.lb_TxCount.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_TxCount.Location = new System.Drawing.Point(44, 353);
            this.lb_TxCount.Name = "lb_TxCount";
            this.lb_TxCount.Size = new System.Drawing.Size(62, 18);
            this.lb_TxCount.TabIndex = 5;
            this.lb_TxCount.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rx:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tx:";
            // 
            // cB_Baud
            // 
            this.cB_Baud.FormattingEnabled = true;
            this.cB_Baud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cB_Baud.Location = new System.Drawing.Point(0, 85);
            this.cB_Baud.Name = "cB_Baud";
            this.cB_Baud.Size = new System.Drawing.Size(120, 20);
            this.cB_Baud.TabIndex = 2;
            this.cB_Baud.Text = "115200";
            // 
            // bt_Connect
            // 
            this.bt_Connect.Location = new System.Drawing.Point(0, 116);
            this.bt_Connect.Name = "bt_Connect";
            this.bt_Connect.Size = new System.Drawing.Size(120, 30);
            this.bt_Connect.TabIndex = 1;
            this.bt_Connect.Text = "连接";
            this.bt_Connect.UseVisualStyleBackColor = true;
            this.bt_Connect.Click += new System.EventHandler(this.bt_Connect_Click);
            // 
            // cB_Portname
            // 
            this.cB_Portname.FormattingEnabled = true;
            this.cB_Portname.Location = new System.Drawing.Point(0, 38);
            this.cB_Portname.Name = "cB_Portname";
            this.cB_Portname.Size = new System.Drawing.Size(120, 20);
            this.cB_Portname.TabIndex = 0;
            this.cB_Portname.SelectedIndexChanged += new System.EventHandler(this.cB_Portname_SelectedIndexChanged);
            this.cB_Portname.Click += new System.EventHandler(this.cB_Portname_Click);
            // 
            // bt_Send
            // 
            this.bt_Send.Location = new System.Drawing.Point(618, 367);
            this.bt_Send.Name = "bt_Send";
            this.bt_Send.Size = new System.Drawing.Size(93, 48);
            this.bt_Send.TabIndex = 3;
            this.bt_Send.Text = "发送";
            this.bt_Send.UseVisualStyleBackColor = true;
            this.bt_Send.Click += new System.EventHandler(this.bt_Send_Click);
            // 
            // Serial
            // 
            this.Serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Serial_DataReceived);
            // 
            // tim_Update
            // 
            this.tim_Update.Tick += new System.EventHandler(this.tim_Update_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 422);
            this.Controls.Add(this.bt_Send);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tB_Received);
            this.Controls.Add(this.tB_Send);
            this.Name = "Form1";
            this.Text = "串口工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tB_Send;
        private System.Windows.Forms.TextBox tB_Received;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_Clear;
        private System.Windows.Forms.Label lb_RxCount;
        private System.Windows.Forms.Label lb_TxCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cB_Baud;
        private System.Windows.Forms.Button bt_Connect;
        private System.Windows.Forms.ComboBox cB_Portname;
        private System.Windows.Forms.Button bt_Send;
        private System.IO.Ports.SerialPort Serial;
        private System.Windows.Forms.Timer tim_Update;
        private System.Windows.Forms.Label lb_Connect;
    }
}

