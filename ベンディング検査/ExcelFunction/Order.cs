using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ベンディング検査.ExcelFunction
{
    public class Order
    {

        public Order(string order,string client) 
        { 
            OrderNumder = order;
            ClientName = client;
        }
        public string OrderNumder { get; set; }
        public string ClientName { get; set; }
    }

    public class Pipe
    {
        public string OrderNumder { get; set; }
        public string PipeNo { get; set; }
        public DateTime BendingDate { get; set; }

        public Pipe(string order, string pipenumber, DateTime bending )
        {
            
            OrderNumder = order;
            PipeNo = pipenumber;
            BendingDate =  bending;
        }
    }




}
