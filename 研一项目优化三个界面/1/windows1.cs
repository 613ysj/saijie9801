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
    public partial class windows1 : UserControl
    {
        public Form1 form1;

        public PointPairList list1 = new PointPairList();
        public PointPairList list2 = new PointPairList();

        //将string数组转化为double数组
        //public double[] xValue = Array.ConvertAll<string, double>(DrawPoint.CreatePane(),s=>double.Parse(s));
        //public double[] xValue = DrawPoint.CreatePane();

        public int xValueNumber=0;


        public int colunm = 1;

        public double x = 20;

        double num_y1 = 1;
        double num_y2 = 1;
        public int time = 1;


        DateTime dateTime = new DateTime(2014, 7, 20);

        double[,] newList = ExcelServer.Read();
        double[,] y = ExcelServer.Read();

        public static windows1 windows_1;
        public windows1()
        {
            InitializeComponent();
            windows_1 = this;
            DrawPoint.CreatePane(zedGraphControl1, list1);
            DrawPoint.CreatePane(zedGraphControl2, list2);

        }


        private void TimerDraw_Tick_1(object sender, EventArgs e)
        {


            ////更新绘点zedGraphControl
            //double x1 = (double)new XDate(DateTime.Now);       
            //double x1 = 1;


            //num_y1 = (y[1, colunm + 1] - y[1, colunm]) / 10 * time + y[1, colunm];
            //num_y2 = (y[2, colunm + 1] - y[2, colunm]) / 10 * time + y[2, colunm];



            //if (Form1.form1.LineFlag==true)
            //{
            //    zedGraphControl1.GraphPane.CurveList.Clear();

            //    list1.Clear();
            //    colunm = 1;

            //    DrawPoint.CreatePane(zedGraphControl1, list1);
            //    //form1.w1.zedGraphControl1.GraphPane.GraphObjList.Clear();

            //    //zedGraphControl1.AxisChange();
            //    //zedGraphControl1.Refresh();

            //    //zedGraphControl1.GraphPane.AddCurve("", list1, Color.Red, SymbolType.None);

            //    //xValue = (double)new XDate(dateTime);


            //    Form1.form1.LineFlag = false;
            //}
            double xValue = (double)new XDate(dateTime.AddDays(colunm - 1 / 24));
        

            num_y1 = y[1, colunm];
            num_y2 = y[2, colunm];
           

            list1.Add(xValue, num_y1);
            list2.Add(xValue, num_y2);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();

            zedGraphControl2.AxisChange();
            zedGraphControl2.Refresh();

            if ((colunm % 24) == 1)
            {

                var bmp = DrawPoint.Point(Convert.ToInt32(num_y1 * 3000), Convert.ToInt32(num_y2 * 3000));      //上半区画点
                Form1.form1.w1.pictureBox1.Image = bmp;
            }


            if ((colunm++) == 120)
            {
                TimerDraw.Stop();
            }


            //if ((time++) == 10)
            //{
            //    time = 1;
            //    var bmp = DrawPoint.Point(Convert.ToInt32(num_y1), Convert.ToInt32(num_y2));      //上半区画点
            //    Form1.form1.w1.pictureBox1.Image = bmp;
            //    if ((colunm++) == 15)
            //    {
            //        TimerDraw.Stop();
            //    }
            //}
        }
    }
}
