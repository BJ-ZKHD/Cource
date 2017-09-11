using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Width =450;
            this.Height = 480;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();           

        }

        int cnt = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (true)
            {
                this.Refresh();

                Thread.Sleep(1000);
                if (cnt++ == 60)  //+1 /S
                {
                    cnt = 0;
                }                
            }

        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的.


            int X_start = 10;
            int Y_start = 10;
            int  X_len = 400;
            int Y_len = 400;

            Point origin_point = new Point((int)X_start, (int)Y_start);
            Point max_point = new Point( origin_point.X+ X_len, origin_point.Y+ Y_len);

            Pen p1 = new Pen(Color.OrangeRed, 2);//定义了画笔1
            Pen p2 = new Pen(Color.DarkBlue, 1);//定义了画笔2

            g.DrawEllipse(p1,  origin_point.X, origin_point.Y, X_len, Y_len);//在画板上画椭圆,起始坐标为(10,10),外接矩形
            g.DrawLine(new Pen(Color.Gray), new Point(X_start, Y_start+Y_len/2 ), new Point(X_start+X_len , Y_start + Y_len / 2) );  //draw line
            
            int x_dis = X_start + (int)((X_len / 2) * (1 + Math.Sin(Math.PI*2/60 * cnt)));
            int y_dis = Y_start + (int)((Y_len / 2) * (1 - Math.Cos(Math.PI * 2 / 60 * cnt)));

            g.DrawLine(  
                p2, 
                new Point( X_start+X_len/2, Y_start + Y_len / 2), 
                new Point(x_dis, y_dis) 
                );  //draw line       


        }


    }
}
