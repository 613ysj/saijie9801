using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class ExcelServer
    {
        public static double Read(int x,int y)
        {
            XLWorkbook g_wb = new XLWorkbook(@"E:\c#Excel数据读取\练习.xlsx");
            IXLWorksheet sheet = g_wb.Worksheet(1);
           // Form1.form1.txtRead.Text = sheet.Cell(x, y).GetString();
            double flag= sheet.Cell(x, y).GetDouble();
            return flag;
        }
    }
}
