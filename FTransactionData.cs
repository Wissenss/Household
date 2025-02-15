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
	public partial class FTransactionData : Form
	{
		FAccessMode AccessMode = FAccessMode.Create;
		int Id = 0;

		public FTransactionData()
		{
			InitializeComponent();

			ComboBoxAccount.DataSource = Cache.TbAccounts;
			ComboBoxAccount.DisplayMember = "name";
			ComboBoxAccount.ValueMember = "id";

			ComboBoxCategory.DataSource = Cache.TbCategories;
			ComboBoxCategory.DisplayMember = "name";
			ComboBoxCategory.ValueMember = "id";

			LoadAccounts();
			LoadCategories();
		}

		void LoadAccounts()
		{
			Cache.LoadAccounts();
		}

		void LoadCategories()
		{
			Cache.LoadCategories();
		}

		public void SetId(int id)
		{
			Id = id;

			// load the given transaction data
			TAccountTransaction transaction;

			Error error = TransactionsHandler.GetAccountTransactionById(Id, out transaction);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			SetInputsFromTransaction(transaction);
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;
		}

		private void FTransactionData_Load(object sender, EventArgs e)
		{
			if (AccessMode == FAccessMode.Create)
			{
				DatePickerTransactionDate.Value = DateTime.Now;
			}
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void SetInputsFromTransaction(TAccountTransaction transaction)
		{
			DatePickerTransactionDate.Value = transaction.Date;
			TextBoxAmount.Text = (transaction.Amount / 100.00M).ToString();
			ComboBoxAccount.SelectedValue = transaction.Account.Id;
			ComboBoxCategory.SelectedValue = transaction.Category.Id;
			TextBoxDescription.Text = transaction.Description;
		}

		private TAccountTransaction GetTransactionFromInputs()
		{
			TAccountTransaction transaction = new TAccountTransaction()
			{
				Id = Id,
				Date = DatePickerTransactionDate.Value,
				Amount = (int)(double.Parse(TextBoxAmount.Text) * 100),
				Description = TextBoxDescription.Text,

				Account = new TAccount
				{
					Id = (int)ComboBoxAccount.SelectedValue,
				},

				Category = new TCategory
				{
					Id = (int)ComboBoxCategory.SelectedValue
				}
			};

			return transaction;
		}

		private bool Validate()
		{
			StringBuilder errors = new StringBuilder();

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);
				return false;
			}

			return true;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			if (Validate() == false)
			{
				return;
			}

			Error error = TransactionsHandler.SaveTransaction(GetTransactionFromInputs(), AccessMode == FAccessMode.Update);
	
			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			DialogResult = DialogResult.OK;
		}
	}
}
