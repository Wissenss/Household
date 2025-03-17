using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using System.Drawing;

namespace Household
{
	public partial class FMain : Form
	{
		DataSet DSFinance;
		DataTable TbLatestTransactions;
		DataTable TbGlobalAccountTotals;
		DataTable TbLatestAccountTotals;
		DataTable TbLatestCategoryTotals;

		SettingAnalysisPeriodOption AnalysisPeriod = SettingAnalysisPeriodOption.Last30Days;

		bool HighlightSelectedCategoryTransactions;
		bool HighlightSelectedAccountTransactions;

		public FMain()
		{
			InitializeComponent();

			CreateDSFinance();

			// binding the grids to the datasource
			GridGlobalAccountsTotals.DataSource = DSFinance;
			GridGlobalAccountsTotals.DataMember = "TbGlobalAccountTotals";
			GridLatestAccountsTotals.DataSource = DSFinance;
			GridLatestAccountsTotals.DataMember = "TbLatestAccountTotals";
			GridLatestCategoriesTotals.DataSource = DSFinance;
			GridLatestCategoriesTotals.DataMember = "TbLatestCategoryTotals";
			GridLatestTransactions.DataSource = DSFinance;
			GridLatestTransactions.DataMember = "TbLatestTransactions";

			// to avoid laging when resizing
			this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
			this.ResizeEnd += (s, e) => { this.ResumeLayout(true); };
		}

		private void LoadSettings()
		{
			BColorcode.Checked = SettingsHandler.GetSetting("Finance.Colorcode.Toggled", false);
			HighlightSelectedCategoryTransactions = SettingsHandler.GetSetting("Finance.MainDisplay.HightlightSelectedCategoryTransactions", false);
			HighlightSelectedAccountTransactions = SettingsHandler.GetSetting("Finance.MainDisplay.HightlightSelectedAccountTransactions", false);
		}

		private void BAccounts_Click(object sender, EventArgs e)
		{
			using (FAccountsList accounts_list_dialog = new FAccountsList())
			{
				accounts_list_dialog.ShowDialog();

				LoadFinanceDisplay();
			}
		}

		private void BAddTransaction_Click(object sender, EventArgs e)
		{
			using (FTransactionData transaction_date_dialog = new FTransactionData())
			{
				if (transaction_date_dialog.ShowDialog() == DialogResult.OK)
				{
					LoadFinanceDisplay();
				}
			}
		}

		private void CreateDSFinance()
		{
			TbLatestTransactions = new DataTable("TbLatestTransactions", "TbLatestTransactions");
			TbLatestTransactions.Columns.Add("id", typeof(int));
			TbLatestTransactions.Columns.Add("date", typeof(DateTime));
			TbLatestTransactions.Columns.Add("amount", typeof(double));
			TbLatestTransactions.Columns.Add("account_id", typeof(int));
			TbLatestTransactions.Columns.Add("account", typeof(string));
			TbLatestTransactions.Columns.Add("category_id", typeof(int));
			TbLatestTransactions.Columns.Add("category", typeof(string));
			TbLatestTransactions.Columns.Add("description", typeof(string));
			TbLatestTransactions.Columns.Add("use_color", typeof(bool));
			TbLatestTransactions.Columns.Add("color", typeof(Color));
			TbLatestTransactions.Columns.Add("account_use_color", typeof(bool));
			TbLatestTransactions.Columns.Add("account_color", typeof(Color));

			TbGlobalAccountTotals = new DataTable("TbGlobalAccountTotals", "TbGlobalAccountTotals");
			TbGlobalAccountTotals.Columns.Add("id", typeof(int));
			TbGlobalAccountTotals.Columns.Add("name", typeof(string));
			TbGlobalAccountTotals.Columns.Add("balance", typeof(double));
			TbGlobalAccountTotals.Columns.Add("percentage", typeof(double));
			TbGlobalAccountTotals.Columns.Add("use_color", typeof(bool));
			TbGlobalAccountTotals.Columns.Add("color", typeof(Color));

			TbLatestAccountTotals = new DataTable("TbLatestAccountTotals", "TbLatestAccountTotals");
			TbLatestAccountTotals.Columns.Add("id", typeof(int));
			TbLatestAccountTotals.Columns.Add("name", typeof(string));
			TbLatestAccountTotals.Columns.Add("balance", typeof(double));
			TbLatestAccountTotals.Columns.Add("percentage", typeof(double));

			TbLatestCategoryTotals = new DataTable("TbLatestCategoryTotals", "TbLatestCategoryTotals");
			TbLatestCategoryTotals.Columns.Add("id", typeof(int));
			TbLatestCategoryTotals.Columns.Add("name", typeof(string));
			TbLatestCategoryTotals.Columns.Add("balance", typeof(double));
			TbLatestCategoryTotals.Columns.Add("percentage", typeof(double));
			TbLatestCategoryTotals.Columns.Add("color", typeof(Color));
			TbLatestCategoryTotals.Columns.Add("use_color", typeof(bool));
			TbLatestCategoryTotals.Columns.Add("use_percentage", typeof(bool));
			TbLatestCategoryTotals.Columns.Add("condition_percentage", typeof(double));
			TbLatestCategoryTotals.Columns.Add("condition", typeof(BDBTypeLogicalOperator));


			DSFinance = new DataSet("DSFinance");
			DSFinance.Tables.Add(TbLatestTransactions);
			DSFinance.Tables.Add(TbGlobalAccountTotals);
			DSFinance.Tables.Add(TbLatestAccountTotals);
			DSFinance.Tables.Add(TbLatestCategoryTotals);
		}

		private void SetAnalysisPeriod(SettingAnalysisPeriodOption period)
		{
			AnalysisPeriod = period;

			string period_text = "";

			switch (AnalysisPeriod)
			{
				case SettingAnalysisPeriodOption.Last30Days: period_text = "Analysis - last 30 days"; break;
				case SettingAnalysisPeriodOption.Last7Days: period_text = "Ajalysis - last 7 days"; break;
			}

			LStatusStrip1.Text = period_text;
		}

		private void LoadFinanceDisplay()
		{
			SetAnalysisPeriod((SettingAnalysisPeriodOption)SettingsHandler.GetSetting("Finance.Analysis.Period", 1));

			LoadTransactions();
			LoadGlobalAccountTotals();
			LoadLatestAccountTotals();
			LoadLatestCategoryTotals();
		}

		private void LoadTransactions()
		{
			List<TAccountTransaction> account_transactions;

			Error error = TransactionsHandler.GetAccountTransactions(out account_transactions);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			TbLatestTransactions.BeginLoadData();
			TbLatestTransactions.Clear();

			foreach (var transaction in account_transactions)
			{
				DataRow row = TbLatestTransactions.NewRow();

				row["id"] = transaction.Id;
				row["date"] = transaction.Date;
				row["amount"] = transaction.Amount / 100.00M;
				row["account_id"] = transaction.Account.Id;
				row["category_id"] = transaction.Category.Id;
				row["description"] = transaction.Description;
				row["account"] = transaction.Account.Name;
				row["category"] = transaction.Category.Name;
				row["use_color"] = transaction.Category.UseColor;
				row["color"] = transaction.Category.Color;
				row["account_use_color"] = transaction.Account.UseColor;
				row["account_color"] = transaction.Account.Color;

				TbLatestTransactions.Rows.Add(row);
			}

			TbLatestTransactions.EndLoadData();
		}

		private void LoadGlobalAccountTotals()
		{
			List<TAccount> accounts;

			Error error = AccountsHandler.GetAccounts(out accounts);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			int global_total = accounts.Sum(item => item.Balance);

			TbGlobalAccountTotals.BeginLoadData();
			TbGlobalAccountTotals.Clear();

			foreach (var account in accounts)
			{
				DataRow row = TbGlobalAccountTotals.NewRow();

				row["id"] = account.Id;
				row["name"] = account.Name;
				row["balance"] = account.Balance / 100.00M;
				row["use_color"] = account.UseColor;
				row["color"] = account.Color;

				if (global_total != 0)
					row["percentage"] = (account.Balance / global_total);

				TbGlobalAccountTotals.Rows.Add(row);
			}

			DataRow row_total = TbGlobalAccountTotals.NewRow();

			row_total["id"] = "0";
			row_total["name"] = "Total";
			row_total["balance"] = global_total / 100.00M;
			row_total["use_color"] = false;
			row_total["color"] = Color.Transparent;

			TbGlobalAccountTotals.Rows.Add(row_total);

			TbGlobalAccountTotals.EndLoadData();
		}

		private void LoadLatestAccountTotals()
		{
			DateTime from = DateTime.Now;
			DateTime to = DateTime.Now;

			switch (AnalysisPeriod)
			{
				case SettingAnalysisPeriodOption.Last30Days: from = from.AddDays(-30); break;
				case SettingAnalysisPeriodOption.Last7Days: from = from.AddDays(-7); break;
			}

			decimal income;
			decimal outcome;

			Error error = TransactionsHandler.GetIncomeWithinPeriod(from, to, out income);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			error = TransactionsHandler.GetOutcomeWithinPeriod(from, to, out outcome);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			decimal total_income_outcome = income + (outcome * -1);

			TbLatestAccountTotals.BeginLoadData();
			TbLatestAccountTotals.Clear();

			DataRow row = TbLatestAccountTotals.NewRow();

			row["name"] = "Income";
			row["balance"] = income / 100;
			if (total_income_outcome > 0)
				row["percentage"] = income / total_income_outcome;

			TbLatestAccountTotals.Rows.Add(row);

			row = TbLatestAccountTotals.NewRow();

			row["name"] = "Outcome";
			row["balance"] = outcome / 100;
			if (total_income_outcome > 0)
				row["percentage"] = (outcome * -1) / total_income_outcome;

			TbLatestAccountTotals.Rows.Add(row);

			row = TbLatestAccountTotals.NewRow();

			row["name"] = "Total";
			row["balance"] = (income + outcome) / 100;
			row["percentage"] = 1.00M;

			TbLatestAccountTotals.Rows.Add(row);

			TbLatestAccountTotals.EndLoadData();
		}

		private void LoadLatestCategoryTotals()
		{
			DateTime from = DateTime.Now;
			DateTime to = DateTime.Now;

			switch (AnalysisPeriod)
			{
				case SettingAnalysisPeriodOption.Last30Days: from = from.AddDays(-30); break;
				case SettingAnalysisPeriodOption.Last7Days: from = from.AddDays(-7); break;
			}

			Dictionary<int, decimal> totals_per_category;

			Error error = TransactionsHandler.GetTotalsPerCategoryWithinPeriod(from, to, out totals_per_category);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			decimal income;

			error = TransactionsHandler.GetIncomeWithinPeriod(from, to, out income);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			TbLatestCategoryTotals.BeginLoadData();
			TbLatestCategoryTotals.Clear();

			foreach (int category_id in totals_per_category.Keys)
			{
				TCategory category;

				error = CategoriesHandler.GetCategoryById(category_id, out category);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DataRow row = TbLatestCategoryTotals.NewRow();

				row["id"] = category.Id;
				row["name"] = category.Name;
				row["balance"] = totals_per_category[category_id] / 100.00M;

				if (income != 0)
					row["percentage"] = Math.Abs(totals_per_category[category_id] / income);
				
				row["color"] = category.Color;
				row["use_color"] = category.UseColor;
				row["use_percentage"] = category.UsePercentage;
				row["condition_percentage"] = category.Percentage / 100.00M;
				row["condition"] = category.Condition;

				TbLatestCategoryTotals.Rows.Add(row);
			}

			TbLatestCategoryTotals.EndLoadData();
		}

		private void FMain_Load(object sender, EventArgs e)
		{
			Height = SettingsHandler.GetSetting("Application.Window.Height", Height);
			Width = SettingsHandler.GetSetting("Application.Window.Width", Width);

			if (SettingsHandler.SettingExists("Application.Window.Location.X") == 0 && SettingsHandler.SettingExists("Application.Window.Location.Y") == 0)
			{
				StartPosition = FormStartPosition.Manual;
				Location = new Point(SettingsHandler.GetSetting("Application.Window.Location.X", Location.X), SettingsHandler.GetSetting("Application.Window.Location.X", Location.Y));
			}


			if (SettingsHandler.GetSetting("Application.Window.Maximized", false))
			{
				WindowState = FormWindowState.Maximized;
			}

			LoadSettings();
			LoadFinanceDisplay();

			if (TbGlobalAccountTotals.Rows.Count > 0)
			{
				GridGlobalAccountsTotals.Rows[TbGlobalAccountTotals.Rows.Count - 1].Selected = true;
			}

			if (TbLatestAccountTotals.Rows.Count > 0)
			{
				GridLatestAccountsTotals.Rows[TbLatestAccountTotals.Rows.Count - 1].Selected = true;
			}
		}

		private void BCategories_Click(object sender, EventArgs e)
		{
			using (FCategoriesList categories_list_dialog = new FCategoriesList())
			{
				categories_list_dialog.ShowDialog();

				LoadLatestCategoryTotals();
				LoadTransactions();
			}
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadFinanceDisplay();
		}

		private void EditSelectedTransactionRecord()
		{
			if (GridLatestTransactions.SelectedRows.Count > 0)
			{
				DataGridViewRow row = GridLatestTransactions.SelectedRows[0];

				int transaction_id = (int)row.Cells["id"].Value;

				using (FTransactionData transaction_data_dialog = new FTransactionData())
				{
					transaction_data_dialog.SetAccessMode(FAccessMode.Update);
					transaction_data_dialog.SetId(transaction_id);

					if (transaction_data_dialog.ShowDialog() == DialogResult.OK)
					{
						LoadFinanceDisplay();
					}
				}
			}
		}

		private void DeleteSelectedTransactionRecord()
		{
			if (GridLatestTransactions.SelectedRows.Count > 0)
			{
				DataGridViewRow row = GridLatestTransactions.SelectedRows[0];

				int transaction_id = (int)row.Cells["id"].Value;
				DateTime date = (DateTime)row.Cells["date"].Value;
				double amount = (double)row.Cells["amount"].Value;

				if (MessageBox.Show($"This procedure will delete the transaction of {date.ToString()} for {amount}", "Accept Action", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Error error = TransactionsHandler.DeleteAccountTransaction(transaction_id);

					if (error != 0)
					{
						Utilities.ShowErrorDialog(error);
						return;
					}

					LoadFinanceDisplay();
				}
			}
		}

		private void GridLatestTransactions_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				EditSelectedTransactionRecord();

				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
			{
				DeleteSelectedTransactionRecord();

				e.Handled = true;
			}
		}

		private void GridLatestTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (GridLatestTransactions.Columns[e.ColumnIndex].Name == "amount")
			{
				if ((double)e.Value < 0)
				{
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Red;
				}
			}

			if (HighlightSelectedCategoryTransactions)
			{
				int selected_category_id = 0;

				if (GridLatestCategoriesTotals.SelectedRows.Count > 0)
				{
					DataGridViewRow row = GridLatestCategoriesTotals.SelectedRows[0];

					selected_category_id = (int)row.Cells["colId3"].Value;
				}

				int category_id = (int)TbLatestTransactions.Rows[e.RowIndex]["category_id"];

				if (category_id == selected_category_id)
				{
					e.CellStyle.BackColor = Color.Yellow;
				}
			}

			if (HighlightSelectedAccountTransactions)
			{
				int selected_account_id = 0;

				if (GridGlobalAccountsTotals.SelectedRows.Count > 0)
				{
					DataGridViewRow row = GridGlobalAccountsTotals.SelectedRows[0];

					selected_account_id = (int)row.Cells["colAccountId"].Value;
				}

				int account_id = (int)TbLatestTransactions.Rows[e.RowIndex]["account_id"];

				if (account_id == selected_account_id)
				{
					e.CellStyle.BackColor = Color.Yellow;
				}
			}

			if (GridLatestTransactions.Columns[e.ColumnIndex].Name == "Category")
			{
				if ((bool)TbLatestTransactions.Rows[e.RowIndex]["use_color"] && BColorcode.Checked)
				{
					Color color = (Color)TbLatestTransactions.Rows[e.RowIndex]["color"];

					e.CellStyle.BackColor = color;
					e.CellStyle.SelectionBackColor = color;
				}
			}

			if (GridLatestTransactions.Columns[e.ColumnIndex].Name == "Account")
			{
				if ((bool)TbLatestTransactions.Rows[e.RowIndex]["account_use_color"] && BColorcode.Checked)
				{
					Color color = (Color)TbLatestTransactions.Rows[e.RowIndex]["account_color"];

					e.CellStyle.BackColor = color;
					e.CellStyle.SelectionBackColor = color;
				}
			}
		}

		private void GridGlobalAccountsTotals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (GridGlobalAccountsTotals.Columns[e.ColumnIndex].Name == "ColGlobalAccountsTotalsBalance")
			{
				if ((double)e.Value < 0)
				{
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Red;
				}
			}

			if (GridGlobalAccountsTotals.Columns[e.ColumnIndex].Name == "Name4")
			{
				bool use_color = (bool)TbGlobalAccountTotals.Rows[e.RowIndex]["use_color"];
				Color color = (Color)TbGlobalAccountTotals.Rows[e.RowIndex]["color"];

				if (use_color && BColorcode.Checked)
				{
					e.CellStyle.BackColor = color;
					e.CellStyle.SelectionBackColor = color;
				}
			}
		}

		private void GridLatestAccountsTotals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (GridLatestAccountsTotals.Columns[e.ColumnIndex].Name == "colAmount2")
			{
				if ((double)e.Value < 0)
				{
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Red;
				}
			}

			if (e.ColumnIndex == 3 && e.RowIndex == 1)
			{
				if (e.Value is DBNull)
				{
					e.Value = 0.0;
				}

				Color color = (double)e.Value > 0.5 ? Color.LightPink : Color.LightGreen;

				e.CellStyle.BackColor = color;
				e.CellStyle.SelectionBackColor = color;
			}

			if (e.ColumnIndex == 3 && e.RowIndex == 2)
			{
				Color color = GridLatestAccountsTotals.DefaultCellStyle.BackColor;

				if (GridLatestAccountsTotals.SelectedRows[0].Index == 2)
				{
					color = GridLatestAccountsTotals.DefaultCellStyle.SelectionBackColor;
				}

				e.CellStyle.ForeColor = color;
				e.CellStyle.SelectionForeColor = color;
			}
		}

		private Color GetSelectionBackColor(Color row_back_color)
		{
			int alpha = Utilities.TrimOnRange(0, 255, row_back_color.A - 50);
			int red = Utilities.TrimOnRange(0, 255, row_back_color.R - 10);
			int green = Utilities.TrimOnRange(0, 255, row_back_color.G - 10);
			int blue = Utilities.TrimOnRange(0, 255, row_back_color.B - 10);

			return Color.FromArgb(alpha, red, green, blue);
		}

		private void GridLatestCategoriesTotals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (GridLatestCategoriesTotals.Columns[e.ColumnIndex].Name == "colAmount3")
			{
				if ((double)e.Value < 0)
				{
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Red;
				}
			}

			if (GridLatestCategoriesTotals.Columns[e.ColumnIndex].Name == "Name3")
			{
				bool use_color = (bool)TbLatestCategoryTotals.Rows[e.RowIndex]["use_color"];
				Color color = (Color)TbLatestCategoryTotals.Rows[e.RowIndex]["color"];

				if (use_color && BColorcode.Checked)
				{
					e.CellStyle.BackColor = color;
					e.CellStyle.SelectionBackColor = color;
				}
			}

			if (GridLatestCategoriesTotals.Columns[e.ColumnIndex].Name == "Percentage3")
			{
				bool use_percentage = (bool)TbLatestCategoryTotals.Rows[e.RowIndex]["use_percentage"];
				double percentage = (double)TbLatestCategoryTotals.Rows[e.RowIndex]["condition_percentage"];
				BDBTypeLogicalOperator condition = (BDBTypeLogicalOperator)TbLatestCategoryTotals.Rows[e.RowIndex]["condition"];

				if (use_percentage)
				{
					Color color = Color.LightGreen;

					switch (condition)
					{
						case BDBTypeLogicalOperator.less_than: color = (double)e.Value < percentage ? Color.LightGreen : Color.LightPink; break;
						case BDBTypeLogicalOperator.less_than_or_equal_to: color = (double)e.Value <= percentage ? Color.LightGreen : Color.LightPink; break;
						case BDBTypeLogicalOperator.greater_than: color = (double)e.Value > percentage ? Color.LightGreen : Color.LightPink; break;
						case BDBTypeLogicalOperator.greater_than_or_equal_to: color = (double)e.Value >= percentage ? Color.LightGreen : Color.LightPink; break;
						case BDBTypeLogicalOperator.equal_to: color = (double)e.Value == percentage ? Color.LightGreen : Color.LightPink; break;
						case BDBTypeLogicalOperator.not_equal_to: color = (double)e.Value != percentage ? Color.LightGreen : Color.LightPink; break;
					};

					e.CellStyle.BackColor = color;
					e.CellStyle.SelectionBackColor = color;
				}
			}
		}

		private void BSettings_Click(object sender, EventArgs e)
		{
			using (FSettings settings_dialog = new FSettings())
			{
				if (settings_dialog.ShowDialog() == DialogResult.OK)
				{
					LoadSettings();
					LoadFinanceDisplay();
				};
			}
		}

		private void BColorcode_CheckedChanged(object sender, EventArgs e)
		{
			SettingsHandler.SetSetting("Finance.Colorcode.Toggled", BColorcode.Checked);

			GridLatestCategoriesTotals.Refresh();
			GridLatestTransactions.Refresh();
			GridGlobalAccountsTotals.Refresh();
		}

		private void GridLatestCategoriesTotals_SelectionChanged(object sender, EventArgs e)
		{
			GridLatestTransactions.Refresh();
		}

		private void FMain_KeyDown(object sender, KeyEventArgs e)
		{
			//if (e.KeyCode == Keys.Escape)
			//{
			//	Application.Exit();
			//}
		}

		private void FMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			// guardar la config de la ventana
			if (this.WindowState == FormWindowState.Normal)
			{
				SettingsHandler.SetSetting("Application.Window.Height", Height);
				SettingsHandler.SetSetting("Application.Window.Width", Width);
				SettingsHandler.SetSetting("Application.Window.Location.X", Location.X);
				SettingsHandler.SetSetting("Application.Window.Location.X", Location.Y);
			}

			SettingsHandler.SetSetting("Application.Window.Maximized", WindowState == FormWindowState.Maximized);
		}

		private void BExcelExport_Click(object sender, EventArgs e)
		{
			using (FExcelExport excel_export_dialog = new FExcelExport())
			{
				excel_export_dialog.ExportTransactions();
			}
		}

		private void GridGlobalAccountsTotals_SelectionChanged(object sender, EventArgs e)
		{
			GridLatestTransactions.Refresh();
		}

		private void BStatistics_Click(object sender, EventArgs e)
		{
			using (FStatistic statistics_dialog = new FStatistic())
			{
				statistics_dialog.ShowDialog();
			}
		}
	}
}
