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
    public partial class windows2 : UserControl
    {
        public PointPairList list3 = new PointPairList();
        public PointPairList list4 = new PointPairList();

        public static windows2 windows_2;

        public int colunm = 1;
        double num_y3 = 1;
        double num_y4 = 1;
        int time = 1;
        double x1 = (double)new XDate(DateTime.Now);
        double[,] newList = ExcelServer.Read();
        double[,] y = ExcelServer.Read();

        public windows2()
        {
            InitializeComponent();
            windows_2 = this;
            DrawPoint.CreatePane(zedGraphControl3, list3);
            DrawPoint.CreatePane(zedGraphControl4, list4);

        }

        private void TimerDraw_Tick(object sender, EventArgs e)
        {
            ////更新绘点zedGraphControl
            //double x1 = (double)new XDate(DateTime.Now);       
            //double x1 = 1;

            //num_y1 = (y[1, colunm + 1] - y[1, colunm]) / 10 * time + y[1, colunm];
            //num_y2 = (y[2, colunm + 1] - y[2, colunm]) / 10 * time + y[2, colunm];

            num_y3 = y[3, colunm];
            num_y4 = y[4, colunm];

            list3.Add(x1, num_y3);
            list4.Add(x1, num_y4);

            zedGraphControl3.AxisChange();
            zedGraphControl3.Refresh();

            zedGraphControl4.AxisChange();
            zedGraphControl4.Refresh();

            if ((colunm % 24) == 1)
            {

                var bmp = DrawPoint.Point(Convert.ToInt32(num_y3 * 3000), Convert.ToInt32(num_y4 * 3000));      //上半区画点
                Form1.form1.w2.pictureBox1.Image = bmp;
            }

            if ((colunm++) == 120)
            {
                TimerDraw.Stop();
            }

            //if ((time++) == 10)
            //{
            //    time = 1;
            //    var bmp = DrawPoint.Point(Convert.ToInt32(num_y3), Convert.ToInt32(num_y4));      //上半区画点
            //    Form1.form1.w2.pictureBox1.Image = bmp;
            //    if ((colunm++) == 15)
            //    {
            //        TimerDraw.Stop();
            //    }
            //}
        }
    }
}
