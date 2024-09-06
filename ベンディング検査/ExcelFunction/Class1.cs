using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ベンディング検査.ExcelFunction
{
    public  static class ExcelFunction
    {
        public static (List<Order>, List<Pipe>) ReadExcel(string filename)
        {


            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            List<Order> OrderList = new List<Order>();
            List<Pipe> PipeList = new List<Pipe>();
            using (ExcelPackage pck = new ExcelPackage(new FileInfo(filename)))
            {
                var ws = pck.Workbook.Worksheets[0];
                if (ws == null)
                {
                    MessageBox.Show("Sheet 一覧 がありません");
                    return (OrderList,PipeList);
                }

               

                for (int i = 2; i < 2000 && ws.Cells[i, 1].Value != null; i++)
                {
                    OrderList.Add( new Order(
                        ws.Cells[i, 1].Value.ToString().Trim(),
                        ws.Cells[i, 2].Value.ToString().Trim()
                        
                        ));
                }

                  ws = pck.Workbook.Worksheets[1];
                if (ws == null)
                {
                    MessageBox.Show("Sheet 一覧 がありません");
                    return (OrderList, PipeList);
                }

               

                for (int i = 2; i < 2000 && ws.Cells[i, 1].Value != null; i++)
                {
                    long dateNum = long.Parse(ws.Cells[i, 3].Value.ToString());
                    DateTime date = DateTime.FromOADate(dateNum);

                    PipeList.Add( new Pipe(
                        ws.Cells[i, 1].Value.ToString().Trim(),
                        ws.Cells[i, 2].Value.ToString().Trim(),
                        date
                        ));
                }
                return (OrderList, PipeList);

            }

        }
    }
}
