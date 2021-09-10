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
using System.IO;
using System.Diagnostics;

namespace _1
{
    public partial class Form1 : Form
    {
        public static Form1 form1;    //1:

        //定义使用到的曲线图的坐标集
        PointPairList list1 = new PointPairList();
        PointPairList list2 = new PointPairList();
        PointPairList list3 = new PointPairList();
        PointPairList list4 = new PointPairList();
    
        int num_y = 1;

        public Form1()
        {
            
            InitializeComponent();

            form1 = this;           //2:(通过1，2)其他文件能调用Form1中的控件
            
            DrawPoint.CreatePane(zedGraphControl1,list1); //画折线图
            DrawPoint.CreatePane(zedGraphControl2,list2);
            DrawPoint.CreatePane(zedGraphControl3,list3);
            DrawPoint.CreatePane(zedGraphControl4,list4);

            //string str1 = Directory.GetCurrentDirectory();
            //textBox1.Text = str1;
        }


        //每1s刷新一次
        private void TimerDraw_Tick(object sender, EventArgs e)
        {
            //实时显示（年:月:日 小时:分钟:秒）的格式
            string timeStr = DateTime.Now.ToString("yyyy-MM-dd  HH;mm;ss");
            // timeField.Text = timeStr;

            //更新（增加）折线图的坐标并将y坐标的值打印出来
            double y1 = DrawPoint.Update(1, num_y, list1, zedGraphControl1);
            double y2 = DrawPoint.Update(2, num_y, list2, zedGraphControl2);
            double y3 = DrawPoint.Update(3, num_y, list3, zedGraphControl3);
            double y4 = DrawPoint.Update(4, num_y, list4, zedGraphControl4);

            DrawPoint.Point(Convert.ToInt32(y1), Convert.ToInt32(y2), Convert.ToInt32(y3), Convert.ToInt32(y4));      //上半区画点
            if((num_y++)==16) TimerDraw.Stop();
        }
    }
}
