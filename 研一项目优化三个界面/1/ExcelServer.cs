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
        //将Excel内容全写在数组中
        public static double[,] Read()
        {
            string str1 = Directory.GetCurrentDirectory();
            string path1 = str1;
            string path2 = "TestNew.xlsx";
            string newpath = Path.Combine(path1, path2);

            XLWorkbook g_wb = new XLWorkbook(newpath);

            IXLWorksheet sheet = g_wb.Worksheet(1);
            int ColLength = sheet.LastColumnUsed().ColumnNumber();//查看Excel列数
            int RowLength = sheet.LastRowUsed().RowNumber();//查看Excel行数

            double[,] flags = new double[RowLength+1,ColLength+1];
            for (int i = 1; i < RowLength+1; i++)
            {
                for (int j = 1; j < ColLength+1; j++)
                {
                    flags[i, j] = sheet.Cell(i, j).GetDouble();
                }
            }
            //double flag = sheet.Cell(x, y).GetDouble();

            return flags;
        }
    }
}
