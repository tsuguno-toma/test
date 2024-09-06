using Microsoft.Office.Interop.Excel;
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
using Application = Microsoft.Office.Interop.Excel.Application;
using Excel = Microsoft.Office.Interop.Excel;
using TextBox = System.Windows.Controls.TextBox;

namespace ベンディング検査
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
			if (string.IsNullOrEmpty(fpath.Text))
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "Excelファイル (*.xlsx;*.xls;*.xlsm)|*.xlsx;*.xls;*.xlsm";
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

				if (openFileDialog.ShowDialog() == true)
				{
					// 選択されたファイルのパスをテキストボックスに設定
					fpath.Text = openFileDialog.FileName;
				}
			}

			if (!string.IsNullOrWhiteSpace(fpath.Text) && !lstNames.Items.Contains(fpath.Text))
			{
				// テキストボックスから Excel ファイルのパスを取得
				string excelFilePath = fpath.Text.Replace("\"", "");


				// Excel アプリケーションを起動
				var excelApp = new Application();
				var workbook = excelApp.Workbooks.Open(excelFilePath);
				var worksheet = (Worksheet)workbook.Sheets["L集計"]; // 「L集計」という名前のシートを選択

				// H列のセルの値をlstNamesに追加
				for (int row = 1; row <= worksheet.UsedRange.Rows.Count; row++)
				{
					Range cellH = worksheet.Cells[row, 8]; // H列のセルを選択
					Range cellI = worksheet.Cells[row, 9]; // I列のセルを選択
					Range cellO = worksheet.Cells[row, 15]; // O列のセルを選択
					Range cellQ = worksheet.Cells[row, 17]; // Q列のセルを選択
					string cellValueH = cellH.Value?.ToString(); // H列のセルの値を文字列に変換
					string cellValueI = cellI.Value?.ToString(); // I列のセルの値を文字列に変換
					string cellValueO = cellO.Value?.ToString(); // O列のセルの値を文字列に変換
					string cellValueQ = cellQ.Value?.ToString(); // Q列のセルの値を文字列に変換
					if (!string.IsNullOrEmpty(cellValueH) && cellValueH.Contains("集計")) // H列のセルの値が空でなく、「集計」を含む場合のみ処理を行う
					{
						cellValueH = cellValueH.Replace("集計", ""); // 「集計」というテキストを削除
						cellValueI += "本"; // I列のテキストの後に「本」を追加
						cellValueO += "m"; // O列のテキストの後に「m」を追加
										   // Q列の値を日本円表示に変更
						if (double.TryParse(cellValueQ, out double amount))
						{
							cellValueQ = "¥" + amount.ToString("N0"); // 数値を日本円の形式に変換
						}
						string combinedValue = cellValueH + " " + cellValueI + " " + cellValueO + " " + cellValueQ; // H列、I列、O列、Q列の値を結合
						if (!lstNames.Items.Contains(combinedValue)) // リストボックスに値がまだ存在しない場合
						{
							lstNames.Items.Add(combinedValue); // リストボックスに追加
						}
					}
					this.DoEvents();
				}

				// 元の Excel ファイルを閉じる
				workbook.Close(false);

			}
		}
	}
}
