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

namespace Household
{
	public partial class FSettings : Form
	{
		DataSet DSSettings;
		DataTable TbAnalysisPeriodOptions;

		public FSettings()
		{
			InitializeComponent();

			// create dataset structure
			TbAnalysisPeriodOptions = new DataTable("TbAnalysisPeriodOptions", "TbAnalysisPeriodOptions");
			TbAnalysisPeriodOptions.Columns.Add("Value", typeof(SettingAnalysisPeriodOption));
			TbAnalysisPeriodOptions.Columns.Add("Text", typeof(string));

			DSSettings = new DataSet();
			DSSettings.Tables.Add(TbAnalysisPeriodOptions);

			ComboBoxAnalysisPeriod.DataSource = TbAnalysisPeriodOptions;
			ComboBoxAnalysisPeriod.ValueMember = "Value";
			ComboBoxAnalysisPeriod.DisplayMember = "Text";

			// load the comboboxes SIDE-NOTE: deam you microsoft
			LoadAnalysisPeriodOptions();
		}

		private void FSettings_Load(object sender, EventArgs e)
		{
			ComboBoxAnalysisPeriod.SelectedValue = (SettingAnalysisPeriodOption)SettingsHandler.GetSetting("Finance.Analysis.Period", (int)1);
			CheckBoxHighlightTransactionsPeroCategory.Checked = SettingsHandler.GetSetting("Finance.MainDisplay.HightlightSelectedCategoryTransactions", false);
			CheckBoxHighlightSelectedAccountTransactions.Checked = SettingsHandler.GetSetting("Finance.MainDisplay.HightlightSelectedAccountTransactions", false);
		}

		private bool Validate()
		{
			// TODO

			return true;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			if (Validate() == false)
			{
				return;
			}

			SettingsHandler.SetSetting("Finance.Analysis.Period", (int)ComboBoxAnalysisPeriod.SelectedValue);
			SettingsHandler.SetSetting("Finance.MainDisplay.HightlightSelectedCategoryTransactions", CheckBoxHighlightTransactionsPeroCategory.Checked);
			SettingsHandler.SetSetting("Finance.MainDisplay.HightlightSelectedAccountTransactions", CheckBoxHighlightSelectedAccountTransactions.Checked);

			DialogResult = DialogResult.OK;
		}

		private void TbAnalysisPeriodAddRow(SettingAnalysisPeriodOption value, string text)
		{
			DataRow row = TbAnalysisPeriodOptions.NewRow();

			row["Value"] = value;
			row["Text"] = text;

			TbAnalysisPeriodOptions.Rows.Add(row);
		}

		private void LoadAnalysisPeriodOptions()
		{
			TbAnalysisPeriodOptions.BeginLoadData();
			TbAnalysisPeriodOptions.Clear();

			TbAnalysisPeriodAddRow(SettingAnalysisPeriodOption.Last30Days, "Last 30 days");
			TbAnalysisPeriodAddRow(SettingAnalysisPeriodOption.Last7Days, "Last 7 days");

			TbAnalysisPeriodOptions.EndLoadData();
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void ComboBoxAnalysisPeriod_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
