
using BendingCheck;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using TextBox = System.Windows.Controls.TextBox;

namespace BendingCheck
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();


		}

		private void jsorder_Click(object sender, RoutedEventArgs e)
		{
			// テキストボックスが空の場合にファイル選択ダイアログを開く
			//if (string.IsNullOrEmpty(fpath.Text))
			//{
			//	OpenFileDialog openFileDialog = new OpenFileDialog();
			//	openFileDialog.Filter = "Excelファイル (*.xlsx;*.xls;*.xlsm)|*.xlsx;*.xls;*.xlsm";
			//	openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			//	if (openFileDialog.ShowDialog() == true)
			//	{
			//		// 選択されたファイルのパスをテキストボックスに設定
			//		fpath.Text = openFileDialog.FileName;
			//	}
			//}

			//if (!string.IsNullOrWhiteSpace(fpath.Text) && !lstNames.Items.Contains(fpath.Text))
			//{
			//	// テキストボックスから Excel ファイルのパスを取得
			//	string excelFilePath = fpath.Text.Replace("\"", "");


			//}

			
		}

        private void Excelpath_DragOver(object sender, DragEventArgs e)
        {

        }

        private void lstNames2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Excelpath_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Excelpath_Drop(object sender, DragEventArgs e)
        {

        }

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			viewmodel.OpenPDF();
		}

		MainViewModel viewmodel;
		private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{

			viewmodel = this.DataContext as MainViewModel;
		}
	}
}
