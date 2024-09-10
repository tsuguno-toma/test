using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFunction
{
    public class Order
    {

        public Order(string order,string client, string material, double dia, double t, string bend, string creater, DateTime day ) 
        { 
            OrderNumder = order;
            ClientName = client;
            Material = material;
            Diameter = dia;
            ThickNess = t;
            BendNumber = bend;
            Creator = creater;
            DueDay = day;
        }
        public string OrderNumder { get; set; }
        public string ClientName { get; set; }
        public string Material { get; set; }
        public double Diameter { get; set; }
        public double ThickNess { get; set; }
        public string BendNumber { get; set; }
        public string Creator { get; set; }
        public DateTime DueDay { get; set; }
    }

    public class Pipe
    {
        public string OrderNumder { get; set; }
        public string PipeNo { get; set; }
        public DateTime BendingDate { get; set; }
        public string FileName { get; set; }

        public Pipe(string order, string pipenumber, DateTime bending, string filename  )
        {
            
            OrderNumder = order;
            PipeNo = pipenumber;
            BendingDate =  bending;
            FileName = filename;
        }
    }




}
