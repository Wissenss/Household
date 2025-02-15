using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace Household
{
	public partial class FAccountData : Form
	{
		public FAccessMode AccessMode = FAccessMode.Create;
		int AccountId;

		public FAccountData()
		{
			InitializeComponent();
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			TextBoxName.ReadOnly = AccessMode == FAccessMode.Read;

			BAccept.Visible = AccessMode != FAccessMode.Read;
			BCancel.Text = AccessMode == FAccessMode.Read ? "&Cerrar" : "&Cancelar";
		}

		public void SetAccountId(int account_id)
		{
			AccountId = account_id;

			TAccount account;

			Error error = AccountsHandler.GetAccountById(AccountId, out account);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			SetInputsFromAccount(account);
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void SetInputsFromAccount(TAccount account)
		{
			AccountId = account.Id;
			TextBoxName.Text = account.Name;
			CheckBoxUseColor.Checked = account.UseColor;
			ColorDialog.Color = account.Color;
			PanelColor.BackColor = ColorDialog.Color;
		}

		private TAccount GetAccountFromInputs()
		{
			TAccount account = new TAccount()
			{
				Id = AccountId,
				Name = TextBoxName.Text,
				UseColor = CheckBoxUseColor.Checked,
				Color = ColorDialog.Color
			};

			return account;
		}

		private async void BAccept_Click(object sender, EventArgs e)
		{
			TAccount account = GetAccountFromInputs();

			Error error = AccountsHandler.SaveAccount(account, AccessMode == FAccessMode.Update);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);

				return;
			}

			DialogResult = DialogResult.OK;
		}

		private void PanelColor_Click(object sender, EventArgs e)
		{
			if (ColorDialog.ShowDialog() == DialogResult.OK)
			{
				PanelColor.BackColor = ColorDialog.Color;
			}
		}
	}
}
