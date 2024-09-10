using MaterialDesignDemo.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ベンディング検査.ExcelFunction;

namespace ベンディング検査
{
    public class MainViewModel:ViewModelBase
    {

        public MainViewModel()
        {
            var excelname = System.IO.Path.Combine(Directory.GetCurrentDirectory(),  "オーダー＆管番号テーブル.xlsx");


            OpenExcel(excelname);


		}

        public void OpenExcel(string excelname)
        {
			if (File.Exists(excelname))
			{
				(OrderList, AllPipeList) = ExcelFunction.ExcelFunction.ReadExcel(excelname);
				Filename = excelname;

			}
		}

        public string Filename = "";
       
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

		private Pipe selectedPipe;

		public Pipe SelectedPipe { get => selectedPipe; set => SetProperty(ref selectedPipe, value); }


        public void OpenPDF()
        {
            if (SelectedPipe == null) return;
            string filename = Path.Combine(Path.GetDirectoryName(Filename), "明細pdf", SelectedPipe.FileName);

			if (File.Exists(filename))
            {
				ProcessStartInfo sInfo = new ProcessStartInfo(filename)
				{
					//UseShellExecute = true,
					UseShellExecute = true,
					
				};
				
			   Process.Start(sInfo);
			
            }
        }

	}
}
