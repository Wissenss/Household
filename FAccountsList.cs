using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace Household
{
	public partial class FAccountsList : Form
	{
		public FAccountsList()
		{
			InitializeComponent();

			GridAccounts.DataSource = Cache.DSCatalogs;
			GridAccounts.DataMember = "TbAccounts";
		}

		private void FAccountsList_Load(object sender, EventArgs e)
		{
			LoadList();
		}

		private void LoadList()
		{
			Cursor = Cursors.WaitCursor;

			Cache.LoadAccounts();

			Cursor = Cursors.Default;
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FAccountData account_data_dialog = new FAccountData())
			{
				account_data_dialog.AccessMode = FAccessMode.Create;

				if (account_data_dialog.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void GridAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (GridAccounts.Columns[e.ColumnIndex].Name == "balance")
			{
				if ((double)e.Value < 0)
				{
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Red;
				}
			}
		}

		private int GetSelectedAccountId()
		{
			if (GridAccounts.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = GridAccounts.SelectedRows[0];

			int account_id = (int)row.Cells["id"].Value;

			return account_id;
		}


		private void BEdit_Click(object sender, EventArgs e)
		{
			int account_id = GetSelectedAccountId();

			if (account_id == 0)
			{
				return;
			}

			using (FAccountData account_data_dialog = new FAccountData())
			{
				account_data_dialog.SetAccessMode(FAccessMode.Update);
				account_data_dialog.SetAccountId(account_id);

				if (account_data_dialog.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}
	}
}
