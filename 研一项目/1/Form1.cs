using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Threading;

using ClosedXML.Excel;


namespace _1
{
    public partial class Form1 : Form
    {
        PointPairList list1 = new PointPairList();
        PointPairList list2 = new PointPairList();
        PointPairList list3 = new PointPairList();
        PointPairList list4 = new PointPairList();

        Random ran = new Random();
        int Time_flag = 0;
        public static Form1 form1;

        int num_x =1;
        int num_y1 = 1;
        int num_y2 = 1;
        int num_y3 = 1;
        int num_y4 = 1;


        public Form1()
        {
            
            InitializeComponent();

            form1 = this;           //其他文件能调用Form1中的控件
            
            CreatePane(zedGraphControl1,list1); //画折线图
            CreatePane(zedGraphControl2,list2);
            CreatePane(zedGraphControl3,list3);
            CreatePane(zedGraphControl4,list4);
        }

        //画折线图(zed控件,坐标集合list)
        public static void CreatePane(ZedGraphControl zgc, PointPairList list)
        {
            //PointPairList list1 = Form1.PPL();
            GraphPane myPane = zgc.GraphPane;

            myPane.CurveList.Clear();            //每次绘图前都清空绘制区 

            //设置图表标题 和 x y 轴标题
            myPane.Title.Text = "浓度数据曲线";

            myPane.XAxis.Title.Text = "时间";

            myPane.YAxis.Title.Text = "浓度";

            //更改标题的字体

            //  FontSpec myFont = new FontSpec("Arial", 20, Color.Black , false, false, false);

            //标题，x，y轴的字体以及背景以及填充颜色
            FontSpec myFont = new FontSpec("Arial", 16, Color.Black, false, false, false, Color.Transparent, Brushes.Transparent, FillType.None);

            myPane.Title.FontSpec = myFont;       //字体规格

            myPane.XAxis.Title.FontSpec = myFont;

            myPane.YAxis.Title.FontSpec = myFont;

         //   form1.list1.Add(x, y);

            // 用list1生产一条曲线，标注是“曲线1”

            LineItem myCurve = myPane.AddCurve("", list, Color.Red, SymbolType.Star);

            //填充图表颜色

            //myPane.Fill = new Fill(Color.Transparent, Color.FromArgb(200, 200, 255), 45.0f);

            ////三个背景填充属性都设置为透明时背景透明
            //zedGraphControl1.GraphPane.Chart.Fill = new Fill(Color.Transparent, Color.Transparent, 45.0f);
            //zedGraphControl1.MasterPane.Fill = new Fill(Color.Transparent, Color.Transparent, 45.0f);
            //zedGraphControl1.GraphPane.Fill.Color = Color.Transparent;

            //以上生成的图标X轴为数字，下面将转换为日期的文本

            string[] labels = new string[16];   //x轴显示的位数

            for (int i = 0; i < 16; i++)        //x轴显示的内容
            {

                //labels[i] = DateTime.Now.AddDays(i).ToShortDateString();
                labels[i] = DateTime.Now.AddDays(i).ToString("MM - dd");

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
        //更新绘折线
        //public static void UPdatePane(ZedGraphControl zgc, int num_x, int num_y)
        //{
        //    //更新绘点
        //    double x1 = (double)new XDate(DateTime.Now);
        //    //double y1 = ran.NextDouble();
        //    double y1 = ExcelServer.Read(num_x = 1, num_y++);
        //    form1.list1.Add(x1, y1);
        //    zgc.AxisChange();
        //    zgc.Refresh();
        //}
        private void button1_Click(object sender, EventArgs e) //重绘
        {
            if ((Time_flag++)%2==0) TimerDraw.Stop();    //关闭计数器TimerDraw
            else TimerDraw.Start();
          //  DrawPoint.CreatePane(zedGraphControl1);
        }

        private void OnButtonClicked(object sender, EventArgs e) //显示时间
        {
            string timeStr = DateTime.Now.ToString("yyyy-MM-dd  HH;mm;ss");
           // timeField.Text = timeStr;
        }
        //每1s刷新一次
        private void TimerDraw_Tick(object sender, EventArgs e)
        {
            string timeStr = DateTime.Now.ToString("yyyy-MM-dd  HH;mm;ss");
           // timeField.Text = timeStr;

            //更新绘点zedGraphControl1
            double x1 = (double)new XDate(DateTime.Now);
            //double y1 = ran.NextDouble();
            double y1 = ExcelServer.Read(num_x = 1, num_y1++);
            list1.Add(x1, y1);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();

            //更新绘点zedGraphControl2
            double y2 = ExcelServer.Read(num_x = 2, num_y2++);
            list2.Add(x1, y2);
            zedGraphControl2.AxisChange();
            zedGraphControl2.Refresh();

            //更新绘点zedGraphControl3
            double y3 = ExcelServer.Read(num_x = 3, num_y3++);
            list3.Add(x1, y3);
            zedGraphControl3.AxisChange();
            zedGraphControl3.Refresh();

            //更新绘点zedGraphControl4
            double y4 = ExcelServer.Read(num_x = 4, num_y4++);
            list4.Add(x1, y4);
            zedGraphControl4.AxisChange();
            zedGraphControl4.Refresh();

            DrawPoint.Point(Convert.ToInt32(y1), Convert.ToInt32(y2), Convert.ToInt32(y3), Convert.ToInt32(y4));      //上半区画点
            //pictureBox1.Image= DrawPoint.Point(); //将画的点给到picturebox
            if(num_y1==16) TimerDraw.Stop();
        }
    }
}
