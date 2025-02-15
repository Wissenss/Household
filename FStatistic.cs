using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Household
{
	public partial class FStatistic : Form
	{
		DataSet DSStatistics;
		DataTable TbAcccountTransactions;

		public FStatistic()
		{
			InitializeComponent();

			DSStatistics = new DataSet();

			TbAcccountTransactions = new DataTable("TbAcccountTransactions");
			TbAcccountTransactions.Columns.Add("id", typeof(int));
			TbAcccountTransactions.Columns.Add("date", typeof(DateTime));
			TbAcccountTransactions.Columns.Add("amount", typeof(double));
			TbAcccountTransactions.Columns.Add("account_id", typeof(int));
			TbAcccountTransactions.Columns.Add("category_id", typeof(int));
			TbAcccountTransactions.Columns.Add("description", typeof(string));
			DSStatistics.Tables.Add(TbAcccountTransactions);
		}
		
		private void FStatistic_Load(object sender, EventArgs e)
		{
			LoadTbAccountTransactions();

			ChartMain.DataSource = TbAcccountTransactions;
			ChartMain.Series[0].XValueMember = "date";
			ChartMain.Series[0].XAxisType = AxisType.Primary;
			ChartMain.Series[0].XValueType = ChartValueType.DateTime;
			ChartMain.Series[0].YValueMembers = "amount";
			ChartMain.Series[0].YValueType = ChartValueType.Double;

			ChartMain.Series[0].BorderWidth = 2;
			ChartMain.Series[0].Color = SystemColors.HotTrack;

			ChartMain.ChartAreas[0].AxisX.LabelStyle.Format = "dd/mm/yyyy";
			ChartMain.ChartAreas[0].AxisX.LineDashStyle = ChartDashStyle.DashDot;
			//ChartMain.ChartAreas[0].AxisX.MinorGrid.LineWidth = 0;
			ChartMain.ChartAreas[0].AxisY.LabelStyle.Format = "C2";
			ChartMain.ChartAreas[0].AxisY.Interval = 2000;
			//ChartMain.ChartAreas[0].AxisY.LineColor = SystemColors.Control;
			//ChartMain.ChartAreas[0].AxisY.LabelStyle.ForeColor = 
			//ChartMain.AxisY[0].Separator.StrokeThickness = 0
		}

		private void LoadTbAccountTransactions()
		{
			List<TAccountTransaction> transactions;

			Error error = TransactionsHandler.GetAccountTransactions(out transactions);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			transactions.Reverse(); // flip the order to get accurate results

			TbAcccountTransactions.BeginLoadData();
			TbAcccountTransactions.Clear();

			double accumulated = 0;

			foreach (TAccountTransaction transaction in transactions)
			{
				DataRow row = TbAcccountTransactions.NewRow();

				accumulated += transaction.Amount;

				row["id"] = transaction.Id;
				row["date"] = transaction.Date;
				row["amount"] = accumulated / 100;
				row["account_id"] = transaction.Account.Id;
				row["category_id"] = transaction.Category.Id;
				row["description"] = transaction.Description;

				TbAcccountTransactions.Rows.Add(row);
			}

			TbAcccountTransactions.EndLoadData();
		}

	}
}
