using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialTool
{
    public partial class Form1 : Form
    {
        const int Rx_Buff_Size = 400;
        int serialtx_count = 0;
        int serialrx_count = 0;
        string[] strArr = new string[0];
        string[] strpp = new string[0];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tim_Update.Start();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bt_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Serial.IsOpen)
                {
                    Serial.BaudRate = Convert.ToInt32(cB_Baud.Text);
                    Serial.PortName = cB_Portname.Text;
                    Serial.Open();
                }
                else
                {
                    Serial.Close();
                }
        }
            catch
            {
                lb_Connect.Text = "请检查端口";
            }
        }

        private void bt_Send_Click(object sender, EventArgs e)
        {
            if(Serial.IsOpen)
            {
                Serial.Write(tB_Send.Text);
                serialtx_count += tB_Send.TextLength;
            }
        }

        private void tim_Update_Tick(object sender, EventArgs e)
        {
            if (Serial.IsOpen)
            {
                lb_Connect.Text = "已连接";
            }
            else
            {
                lb_Connect.Text = "已断开连接";
            }

            lb_RxCount.Text = serialrx_count.ToString();
            lb_TxCount.Text = serialtx_count.ToString();
        }

        private void Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] Rx_Buff = new byte[Rx_Buff_Size];

            int ReadByte_Size = Serial.Read(Rx_Buff, 0, Serial.BytesToRead);

            if (ReadByte_Size == 0)
                return;

            serialrx_count += ReadByte_Size;
            Invoke((EventHandler)(delegate
            {
                tB_Received.Text += Encoding.UTF8.GetString(Rx_Buff);
            }
            ));
        }

        private void bt_Clear_Click(object sender, EventArgs e)
        {
            serialrx_count = 0;
            serialtx_count = 0;

            tB_Received.Text = "";
            tB_Send.Text = "";
        }

        private void cB_Portname_SelectedIndexChanged(object sender, EventArgs e)
        {
            Update_Port_Info(cB_Portname);
        }
        #region 更新端口信息
        public bool Update_Port_Info(ComboBox p)
        {
            bool Update_Flag = false;
            
            strArr = SerialPort.GetPortNames();
            List<string> OmitPort = new List<string>();

            if (!IsPortListSame(strArr, strpp))
            {
                strpp = strArr;

                p.Items.Clear();

                foreach (var i in strArr)
                {
                    p.Items.Add(i);
                }

                Update_Flag = true;
            }

            return Update_Flag;
        }

        bool IsPortListSame(string[] src, string[] target)
        {
            bool temp = false;
            if (src != null && target != null)
            {
                for (int i = 0; i < src.Length; i++)
                {
                    try
                    {
                        if (src[i] == target[i])
                        {
                            temp = true;
                        }
                    }
                    catch
                    {

                    }
                }
            }

            return temp;
        }

        private void cB_Portname_Click(object sender, EventArgs e)
        {
            Update_Port_Info(cB_Portname);
        }
        #endregion
    }
}
