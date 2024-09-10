using DevExpress.Export.Xl;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ExcelFunction
{
    public  static class ExcelFunction
    {
         public static double ParseDoubleValue(this object val)
        {
            //   @"^\d{0,}.{0,1}\d{0,}$"



            if (val == null) return 0;

            if (val.ToString().Trim() == "") return 0;
            if (val.ToString().Trim() == "-") return 0;

            var check = Regex.IsMatch(val.ToString().Trim(), @"^-{0,1}\d{0,}[.]{0,1}\d{0,}$");

            if (check)
            {
                return double.Parse(val.ToString().Trim());
            }
            else
            {
                return 0;
            }
        }
            public static DateTime ParseDateValue(this string val)
        {
            //   @"^\d{0,}.{0,1}\d{0,}$"
            if(string.IsNullOrEmpty(val)) return DateTime.MinValue;
            var check = Regex.IsMatch(val.ToString().Trim(), @"^[0-9]{1,}$");
            if (check)
            {
                long dateNum = long.Parse(val);
                DateTime date = DateTime.FromOADate(dateNum);
                return date;
            }
            else
            try
            {
               return DateTime.Parse(val);

                long dateNum = long.Parse(val);
                DateTime date = DateTime.FromOADate(dateNum);
                return date;

            }
            catch (Exception e)
            {

             
            }
            return new DateTime();
        }


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
                    ws.Cells[i, 8].Style.Numberformat.Format = "mm/dd/yyyy";
                    OrderList.Add( new Order(
                        ws.Cells[i, 1].Value.ToString().Trim(),
                        ws.Cells[i, 2].Value.ToString().Trim(),
                        ws.Cells[i, 3].Value.ToString().Trim(),
                        ws.Cells[i, 4].Value.ParseDoubleValue(),
                        ws.Cells[i, 5].Value.ParseDoubleValue(),
                        ws.Cells[i, 6].Value.ToString().Trim(),
                        ws.Cells[i, 7].Value.ToString().Trim(),
                        ws.Cells[i, 8].Value.ToString().ParseDateValue()
                        
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
                        date,
						 ws.Cells[i, 4].Value==null?"": ws.Cells[i, 4].Value.ToString().Trim()

						));
                }
                return (OrderList, PipeList);

            }

        }
    }
}
