using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace _1
{
    
    public partial class windows3 : UserControl
    {
        public PointPairList list5 = new PointPairList();
        public PointPairList list6 = new PointPairList();

        public static windows3 windows_3;

        public int colunm = 1;
        double num_y5 = 1;
        double num_y6 = 1;
        int time = 1;
        double x1 = (double)new XDate(DateTime.Now);
        double[,] newList = ExcelServer.Read();
        double[,] y = ExcelServer.Read();

        public windows3()
        {
            InitializeComponent();
            windows_3 = this;
            DrawPoint.CreatePane(zedGraphControl5, list5);
            DrawPoint.CreatePane(zedGraphControl6, list6);
        }

        private void TimerDraw_Tick(object sender, EventArgs e)
        {
            ////更新绘点zedGraphControl
            //double x1 = (double)new XDate(DateTime.Now);       
            //double x1 = 1;

            //num_y1 = (y[1, colunm + 1] - y[1, colunm]) / 10 * time + y[1, colunm];
            //num_y2 = (y[2, colunm + 1] - y[2, colunm]) / 10 * time + y[2, colunm];

            num_y5 = y[5, colunm];
            num_y6 = y[5, colunm];


            list5.Add(x1, num_y5);
            list6.Add(x1, num_y6);

            zedGraphControl5.AxisChange();
            zedGraphControl5.Refresh();

            zedGraphControl6.AxisChange();
            zedGraphControl6.Refresh();

            if ((colunm % 24) == 1)
            {

                var bmp = DrawPoint.Point(Convert.ToInt32(num_y5 * 3000), Convert.ToInt32(num_y6 * 3000));      //上半区画点
                Form1.form1.w3.pictureBox1.Image = bmp;
            }

            if ((colunm++) == 120)
            {
                TimerDraw.Stop();
            }

            //if ((time++) == 10)
            //{
            //    time = 1;
            //    var bmp = DrawPoint.Point(Convert.ToInt32(num_y5), Convert.ToInt32(num_y6));      //上半区画点
            //    Form1.form1.w3.pictureBox1.Image = bmp;
            //    if ((colunm++) == 15)
            //    {
            //        TimerDraw.Stop();
            //    }
            //}
        }
    }
}
