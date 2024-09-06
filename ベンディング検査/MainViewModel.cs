using MaterialDesignDemo.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ベンディング検査.ExcelFunction;

namespace ベンディング検査
{
    public class MainViewModel:ViewModelBase
    {

        public MainViewModel()
        {
            var excelname = System.IO.Path.Combine(Directory.GetCurrentDirectory(),  "オーダー＆管番号テーブル.xlsx");

            if (File.Exists(excelname) )
            {
                (OrderList, AllPipeList) =    ExcelFunction.ExcelFunction.ReadExcel(excelname);
            }

        
        }

        private List<Order> orderList;

        public List<Order> OrderList { get => orderList; set => SetProperty(ref orderList, value); }

        private List<Pipe> pipeList;
        public List<Pipe> PipeList { get => pipeList; set => SetProperty(ref pipeList, value); }

            private List<Pipe> allpipeList;
        public List<Pipe> AllPipeList { get => allpipeList; set => SetProperty(ref allpipeList, value); }




        private Order selectedOrder;

        public Order SelectedOrder
        {
            get => selectedOrder; set
            {
                SetProperty(ref selectedOrder, value);

                if (SelectedOrder == null) return;

                PipeList = AllPipeList.Where(x=>x.OrderNumder == selectedOrder.OrderNumder).ToList();   

            }
        }




    }
}
