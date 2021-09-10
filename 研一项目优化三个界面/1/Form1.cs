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
        public bool LineFlag = false;

        public windows1 w1;
        public windows2 w2;
        public windows3 w3;


        public static Form1 form1;    //1:

        ////定义使用到的曲线图的坐标集
        //PointPairList list1 = new PointPairList();
        //PointPairList list2 = new PointPairList();
        //PointPairList list3 = new PointPairList();
        //PointPairList list4 = new PointPairList();

        double x1 = (double)new XDate(DateTime.Now);
        double[,] newList = ExcelServer.Read();

        byte Change_Num = 0;

        bool stopByte = false; //false时在工作，true时停止工作
        //public bool restartFlag = false;//重置功能，true表示开始重置


        public Form1()
        {
            
            InitializeComponent();

            form1 = this;           //2:(通过1，2)其他文件能调用Form1中的控件
            
            //DrawPoint.CreatePane(zedGraphControl1,list1); //画折线图
            //DrawPoint.CreatePane(zedGraphControl2,list2);
            //DrawPoint.CreatePane(zedGraphControl3,list3);
            //DrawPoint.CreatePane(zedGraphControl4,list4);

            w1 = new windows1();    //给窗体变量赋值
            w2 = new windows2();    //给窗体变量赋值
            w3 = new windows3();    //给窗体变量赋值
            textBox1.Text = "初始界面";
            
        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            int colunm = w1.colunm;
            if (colunm > 15)
            {
                stopByte = true;
            }
            if (stopByte == false)
            {
                windows1.windows_1.TimerDraw.Start();
                windows2.windows_2.TimerDraw.Start();
                windows3.windows_3.TimerDraw.Start();
            }

            if ((Change_Num ++) == 3) Change_Num = 1;
            Control[] controls = { w1, w2, w3 };

            controls[Change_Num-1].Show();  //显示窗体3控件
                         // w3.TopLevel = false;    //重要的一个步骤
            Form1.form1.gpbWindows.Controls.Clear();//清除之前加载的窗体控件
            Form1.form1.gpbWindows.Controls.Add(controls[Change_Num - 1]);//加载窗体2控件
            Form1.form1.textBox1.AppendText("显示窗口"+(Change_Num.ToString())+"\r\n");//输出日志
            
        }

        private void btn_Left_Click(object sender, EventArgs e)
        {
            int colunm = w1.colunm;
            if(colunm>15)
            {
                stopByte = true;
            }
            if (stopByte == false)
            {
                windows1.windows_1.TimerDraw.Start();
                windows2.windows_2.TimerDraw.Start();
                windows3.windows_3.TimerDraw.Start();
            }

            if ((Change_Num--) <= 1) Change_Num = 3;
            Control[] controls = { w1, w2, w3 };

            controls[Change_Num - 1].Show();  //显示窗体3控件
                                              // w3.TopLevel = false;    //重要的一个步骤
            Form1.form1.gpbWindows.Controls.Clear();//清除之前加载的窗体控件
            Form1.form1.gpbWindows.Controls.Add(controls[Change_Num - 1]);//加载窗体2控件
            Form1.form1.textBox1.AppendText("显示窗口" + (Change_Num.ToString()) + "\r\n");//输出日志
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            int colunm = w1.colunm;
            if (colunm<120)
            {
                if (stopByte == true)
                {
                    windows1.windows_1.TimerDraw.Start();
                    windows2.windows_2.TimerDraw.Start();
                    windows3.windows_3.TimerDraw.Start();
                    stopByte = !stopByte;
                    buttonStop.Text = "暂停";
                }
                else
                {
                    windows1.windows_1.TimerDraw.Stop();
                    windows2.windows_2.TimerDraw.Stop();
                    windows3.windows_3.TimerDraw.Stop();
                    stopByte = !stopByte;
                    buttonStop.Text = "开始";
                }
            }
                
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {

            string str1 = Directory.GetCurrentDirectory();
            string path1 = str1;
            //string path2 = "TestNew.xlsx";
            //string newpath = Path.Combine(path1, path2);
            //Form1.form1.w2.pictureBox1.Image.Save("C://Users//saijie//Desktop//dd.bmp");

            //form1.w1.zedGraphControl1.SaveAs("C://Users//saijie//Desktop//dd.bmp");
            form1.w1.zedGraphControl1.GraphPane.CurveList.Clear();
            

            //form1.w1.zedGraphControl1.AxisChange();
            //form1.w1.zedGraphControl1.Refresh();

            w1.colunm = 1;
            w1.list1.Clear();
            w1.list2.Clear();
            w2.colunm = 1;
            w2.list3.Clear();
            w2.list4.Clear();
            w3.colunm = 1;
            w3.list5.Clear();
            w3.list6.Clear();

            DrawPoint.CreatePane(form1.w1.zedGraphControl1, form1.w1.list1);
            DrawPoint.CreatePane(form1.w1.zedGraphControl2, form1.w1.list2);
            DrawPoint.CreatePane(form1.w2.zedGraphControl3, form1.w2.list3);
            DrawPoint.CreatePane(form1.w2.zedGraphControl4, form1.w2.list4);
            DrawPoint.CreatePane(form1.w3.zedGraphControl5, form1.w3.list5);
            DrawPoint.CreatePane(form1.w3.zedGraphControl6, form1.w3.list6);

            //LineFlag = true;
        }
    }
}
