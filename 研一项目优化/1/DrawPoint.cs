using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Threading;
using ClosedXML.Excel;
using System.IO;

namespace _1
{
    class DrawPoint
    {
        //画折线图(zed控件,坐标集合list)
        public static void CreatePane(ZedGraphControl zgc, PointPairList list)
        {
            GraphPane myPane = zgc.GraphPane;

            //查看Excel行数

            string str1 = Directory.GetCurrentDirectory();           
            string path1 = str1;
            string path2 = "Test.xlsx";
            string newpath = Path.Combine(path1, path2);
         //   Form1.form1.textBox1.Text = newpath;

            XLWorkbook g_wb = new XLWorkbook(newpath);

            IXLWorksheet sheet = g_wb.Worksheet(1);
            int ColLength = sheet.LastColumnUsed().ColumnNumber();

            myPane.CurveList.Clear();            //每次绘图前都清空绘制区 

            //设置图表标题 和 x y 轴标题
            myPane.Title.Text = "浓度数据曲线";

            myPane.XAxis.Title.Text = "时间";

            myPane.YAxis.Title.Text = "浓度";

            //更改标题的字体（此时背景为纯白）
            //  FontSpec myFont = new FontSpec("Arial", 20, Color.Black , false, false, false);

            //标题，x，y轴的字体以及背景以及填充颜色(此时背景色为画布的)
            FontSpec myFont = new FontSpec("Arial", 23, Color.Black, false, false, false, Color.Transparent, Brushes.Transparent, FillType.None);

            myPane.Title.FontSpec = myFont;       //字体规格

            ////这样设置不会有边框
            //myPane.Title.FontSpec.Family = "宋体";
            //myPane.Title.FontSpec.Size = 20;

            myPane.XAxis.Title.FontSpec = myFont;//xy轴标题的样式
            myPane.YAxis.Title.FontSpec = myFont;

            myPane.XAxis.Scale.FontSpec.Size = 20;//xy轴的字体大小
            myPane.YAxis.Scale.FontSpec.Size = 20;

            //   form1.list1.Add(x, y);

            // 用list1生产一条曲线，标注是“曲线1”

            // LineItem myCurve = myPane.AddCurve("", list, Color.Red, SymbolType.Star);
            //画的线的格式
            LineItem myCurve = myPane.AddCurve("", list, Color.Red, SymbolType.Default);
           // myCurve.Symbol.Fill = new Fill(Color.Red, Color.White, Color.Red);
            myCurve.Line.Width = 2;  //画线的宽度

            //填充图表颜色
            //myPane.Fill = new Fill(Color.Transparent, Color.FromArgb(200, 200, 255), 45.0f);

            //三个背景填充属性都设置为透明时背景透明
            zgc.GraphPane.Chart.Fill = new Fill(Color.Transparent, Color.Transparent, 45.0f);
            zgc.MasterPane.Fill = new Fill(Color.Transparent, Color.Transparent, 45.0f);
            zgc.GraphPane.Fill.Color = Color.Transparent;

            //以上生成的图标X轴为数字，下面将转换为日期的文本

            string[] labels = new string[ColLength];   //x轴显示的位数

            for (int i = 0; i < ColLength; i++)        //x轴显示的内容
            {

                //labels[i] = DateTime.Now.AddDays(i).ToShortDateString();
                labels[i] = DateTime.Now.AddDays(i).ToString("MM-dd");

            }

            myPane.XAxis.Scale.TextLabels = labels; //X轴文本取值

            myPane.XAxis.Type = AxisType.Text;   //X轴类型


            //画到zedGraphControl控件中，此句必加
            zgc.AxisChange();//在数据变化时绘图
            //更新图表
            zgc.Invalidate();
            //重绘控件
            zgc.Refresh();
        }
        //上半区画点
        public static void Point(int Part1, int Part2, int Part3, int Part4)
        {
            string str1 = Directory.GetCurrentDirectory();
            string path1 = str1;
            string path2 = "background.jpg";
            string newpath = Path.Combine(path1, path2);
            //Form1.form1.textBox1.Text = newpath;

            Bitmap bmp = new Bitmap(newpath);
            //Bitmap bmp = new Bitmap(@"C:\Users\saijie\Desktop\研一项目优化修改文档\1\Resources\核潜艇.jpg");

            Graphics graphics = Graphics.FromImage(bmp);
            Random random = new Random();

            Pen pen = new Pen(Color.Black);
            graphics.DrawLine(pen, bmp.Width / 2, 0, bmp.Width / 2, bmp.Height);
            graphics.DrawLine(pen, 0, bmp.Height / 2, bmp.Width, bmp.Height / 2);


            for (int i = 0; i < Part1; i++)              //第一部分
            {
                // Point point = new Point(random.Next(0, pictureBox1.Width), random.Next(0, pictureBox1.Height));
                Point point = new Point(random.Next(0, bmp.Width / 2-4), random.Next(0, bmp.Height / 2-4)); //会出现的随机点的位置
                graphics.FillEllipse(Brushes.Yellow, point.X, point.Y, 4+2, 4+2);

                //bmp.SetPixel(point.X, point.Y, Color.Black);

            }
            for (int i = 0; i < Part2; i++)             //第二部分
            {
                Point point = new Point(random.Next(bmp.Width / 2+4, bmp.Width), random.Next(0, bmp.Height / 2-4));
                graphics.FillEllipse(Brushes.White, point.X, point.Y, 4+2, 4+2);
            }

            for (int i = 0; i < Part3; i++)            //第三部分
            {
                Point point = new Point(random.Next(0, bmp.Width / 2-4), random.Next(bmp.Height / 2+4, bmp.Height));
                graphics.FillEllipse(Brushes.Red, point.X, point.Y, 4+2, 4+2);
            }
            for (int i = 0; i < Part4; i++)            //第四部分
            {
                Point point = new Point(random.Next(bmp.Width / 2+4, bmp.Width), random.Next(bmp.Height / 2+4, bmp.Height));
                graphics.FillEllipse(Brushes.Black, point.X, point.Y, 4+2, 4+2);
            }
            Form1.form1.pictureBox1.Image = bmp;         
        }
        //更新（增添）折线图的坐标，并返回y坐标的值
        public static double Update(int cow, int colunm, PointPairList list, ZedGraphControl zgc)
        {
            //更新绘点zedGraphControl
            double x1 = (double)new XDate(DateTime.Now);
            //double y1 = ran.NextDouble();
            double y1 = ExcelServer.Read(cow, colunm++);
            list.Add(x1, y1);
            zgc.AxisChange();
            zgc.Refresh();

            return y1;
        }
    }
}
