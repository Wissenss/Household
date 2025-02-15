using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.Office;
using Business;

namespace Household
{
	public partial class FExcelExport : Form
	{
		public FExcelExport()
		{
			InitializeComponent();
		}

		private Row CreateTransactionsHeaderRow()
		{
			Row row = new Row();

			row.Append(new Cell() { CellValue = new CellValue("Date"),				DataType = CellValues.String });
			row.Append(new Cell() { CellValue = new CellValue("Account"),			DataType = CellValues.String });
			row.Append(new Cell() { CellValue = new CellValue("Category"),		DataType = CellValues.String });
			row.Append(new Cell() { CellValue = new CellValue("Description"), DataType = CellValues.String });
			row.Append(new Cell() { CellValue = new CellValue("Amount"),			DataType = CellValues.String });

			return row;
		}

		private Row CreateTransactionsRow(TAccountTransaction transaction)
		{
			Row row = new Row();

			row.Append(new Cell() { CellValue = new CellValue(transaction.Date), DataType = CellValues.Date });
			row.Append(new Cell() { CellValue = new CellValue(transaction.Account.Name), DataType = CellValues.String });
			row.Append(new Cell() { CellValue = new CellValue(transaction.Category.Name), DataType = CellValues.String });
			row.Append(new Cell() { CellValue = new CellValue(transaction.Description), DataType = CellValues.String });
			row.Append(new Cell() { CellValue = new CellValue(transaction.Amount / 100.00M), DataType = CellValues.Number });

			return row;
		}

		public void ExportTransactions()
		{
			SaveFileDialog.FileName = $"Transactions_{DateTime.Now.ToString("ddMMyyyy")}.xlsx";
			SaveFileDialog.Filter = "Excel files (*.xlsx) | All files (*.*)";
			SaveFileDialog.AddExtension = true;

			if (SaveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			using (SpreadsheetDocument document = SpreadsheetDocument.Create(SaveFileDialog.FileName, SpreadsheetDocumentType.Workbook))
			{
				WorkbookPart part = document.AddWorkbookPart();
				part.Workbook = new Workbook();

				WorksheetPart sheet_part = part.AddNewPart<WorksheetPart>();

				SheetData data = new SheetData();

				Row row = CreateTransactionsHeaderRow();

				data.Append(row);

				List<TAccountTransaction> transactions;

				Error error = TransactionsHandler.GetAccountTransactions(out transactions);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
				}

				foreach (TAccountTransaction transaction in transactions)
				{
					row = CreateTransactionsRow(transaction);

					data.Append(row);
				}

				Worksheet work_sheet = new Worksheet(data);

				work_sheet.Append(new Column() { Min = 1, Max = 1, Width = 100, CustomWidth = true }); // Date
				work_sheet.Append(new Column() { Min = 2, Max = 2, Width = 300, CustomWidth = true }); // AccountName
				work_sheet.Append(new Column() { Min = 3, Max = 3, Width = 300, CustomWidth = true }); // CategoryName
				work_sheet.Append(new Column() { Min = 4, Max = 4, Width = 300, CustomWidth = true }); // Description
				work_sheet.Append(new Column() { Min = 5, Max = 5, Width = 300, CustomWidth = true }); // Amount

				sheet_part.Worksheet = work_sheet;

				Sheets sheets = part.Workbook.AppendChild(new Sheets());

				Sheet sheet = new Sheet() { Id = part.GetIdOfPart(sheet_part), SheetId = 1, Name = "Transactions"};
				sheets.Append(sheet);
			}
		}
	}
}
