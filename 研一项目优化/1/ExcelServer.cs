using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class ExcelServer
    {
        //读取Excel内容(在DrawPoint.Update里用到）
        public static double Read(int x,int y)
        {
            string str1 = Directory.GetCurrentDirectory();
            string path1 = str1;
            string path2 = "Test.xlsx";
            string newpath = Path.Combine(path1, path2);
          //  Form1.form1.textBox1.Text = newpath;

            // XLWorkbook g_wb = new XLWorkbook(@"C:\Users\saijie\Desktop\研一项目优化修改文档\1\练习.xlsx");
            XLWorkbook g_wb = new XLWorkbook(newpath);

            IXLWorksheet sheet = g_wb.Worksheet(1);
           // Form1.form1.txtRead.Text = sheet.Cell(x, y).GetString();
            double flag= sheet.Cell(x, y).GetDouble();

            //int ColLength= sheet.LastColumnUsed().ColumnNumber();//查看Excel行数

            return flag;
        }
    }
}
