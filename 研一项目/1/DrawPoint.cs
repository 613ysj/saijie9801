using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Threading;

namespace _1
{
    class DrawPoint
    {
        //绘折线图
        //public static void CreatePane(ZedGraphControl zgc,double x,double y)
        //{
        //     //PointPairList list1 = Form1.PPL();
        //    GraphPane myPane = zgc.GraphPane;

        //    myPane.CurveList.Clear();            //每次绘图前都清空绘制区 

        //    //设置图表标题 和 x y 轴标题
        //    myPane.Title.Text = "浓度数据曲线";

        //    myPane.XAxis.Title.Text = "时间";

        //    myPane.YAxis.Title.Text = "浓度";

        //    //更改标题的字体

        //    //  FontSpec myFont = new FontSpec("Arial", 20, Color.Black , false, false, false);


        //    //标题，x，y轴的字体以及背景以及填充颜色
        //    FontSpec myFont = new FontSpec("Arial", 16, Color.Black, false, false, false, Color.Transparent, Brushes.Transparent, FillType.None);

        //    myPane.Title.FontSpec = myFont;       //字体规格

        //    myPane.XAxis.Title.FontSpec = myFont;

        //    myPane.YAxis.Title.FontSpec = myFont;

        //    // 造一些数据，PointPairList里有数据对x，y的数组

        //    //Random y = new Random();

        //    //PointPairList list1 = new PointPairList();

        //    //for (int i = 0; i < 36; i++)
        //    //{

        //    //    double x = i;

        //    //    //double y1 = 1.5 + Math.Sin((double)i * 0.2);

        //    //    double y1 = y.NextDouble() * 1000;

        //    //    list1.Add(x, y1); //添加一组数据

        //    //}

        //   //  PointPairList list1 = new PointPairList();
           
        //    list1.Add(x, y);

        //    // 用list1生产一条曲线，标注是“曲线1”

        //    LineItem myCurve = myPane.AddCurve("浓度", list1, Color.Red, SymbolType.Star);

        //    //填充图表颜色

        //    //myPane.Fill = new Fill(Color.Transparent, Color.FromArgb(200, 200, 255), 45.0f);

        //    ////三个背景填充属性都设置为透明时背景透明
        //    //zedGraphControl1.GraphPane.Chart.Fill = new Fill(Color.Transparent, Color.Transparent, 45.0f);
        //    //zedGraphControl1.MasterPane.Fill = new Fill(Color.Transparent, Color.Transparent, 45.0f);
        //    //zedGraphControl1.GraphPane.Fill.Color = Color.Transparent;

        //    //以上生成的图标X轴为数字，下面将转换为日期的文本

        //    string[] labels = new string[36];

        //    for (int i = 0; i < 36; i++)
        //    {

        //        labels[i] = DateTime.Now.AddDays(i).ToShortDateString();

        //    }

        //    myPane.XAxis.Scale.TextLabels = labels; //X轴文本取值

        //    myPane.XAxis.Type = AxisType.Text;   //X轴类型

        //    //画到zedGraphControl1控件中，此句必加
        //    zgc.AxisChange();//在数据变化时绘图

        //    //更新图表
        //    Form1.form1.zedGraphControl1.Invalidate();
        //    //重绘控件
        //    Form1.form1.Refresh();
        //}
        //在上半区绘点
        public static void Point(int Part1, int Part2, int Part3, int Part4)
        {
            Bitmap bmp = new Bitmap("C:\\Users\\saijie\\Desktop\\核潜艇.jpg");

            Graphics graphics = Graphics.FromImage(bmp);
            Random random = new Random();

            Pen pen = new Pen(Color.Black);
            graphics.DrawLine(pen, bmp.Width / 2, 0, bmp.Width / 2, bmp.Height);
            graphics.DrawLine(pen, 0, bmp.Height / 2, bmp.Width, bmp.Height / 2);


            for (int i = 0; i < Part1; i++)              //第一部分
            {
                // Point point = new Point(random.Next(0, pictureBox1.Width), random.Next(0, pictureBox1.Height));
                Point point = new Point(random.Next(0, bmp.Width / 2), random.Next(0, bmp.Height / 2)); //会出现的随机点的位置
                graphics.FillEllipse(Brushes.Yellow, point.X, point.Y, 4, 4);

                //bmp.SetPixel(point.X, point.Y, Color.Black);

            }
            for (int i = 0; i < Part2; i++)             //第二部分
            {
                Point point = new Point(random.Next(bmp.Width / 2, bmp.Width), random.Next(0, bmp.Height / 2));
                graphics.FillEllipse(Brushes.Blue, point.X, point.Y, 4, 4);
            }

            for (int i = 0; i < Part3; i++)            //第三部分
            {
                Point point = new Point(random.Next(0, bmp.Width / 2), random.Next(bmp.Height / 2, bmp.Height));
                graphics.FillEllipse(Brushes.Red, point.X, point.Y, 4, 4);
            }
            for (int i = 0; i < Part4; i++)            //第四部分
            {
                Point point = new Point(random.Next(bmp.Width / 2, bmp.Width), random.Next(bmp.Height / 2, bmp.Height));
                graphics.FillEllipse(Brushes.Black, point.X, point.Y, 4, 4);
            }
            Form1.form1.pictureBox1.Image = bmp;         
        }
    }
}
