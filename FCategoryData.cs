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
	public partial class FCategoryData : Form
	{
		FAccessMode AccessMode = FAccessMode.Create;
		int CategoryId = 0;

		public FCategoryData()
		{
			InitializeComponent();

			ComboBoxCondition.DataSource = Cache.TbLogicalOperators;
			ComboBoxCondition.ValueMember = "id";
			ComboBoxCondition.DisplayMember = "text";
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;
		}

		public void SetCategoryId(int id)
		{
			CategoryId = id;

			TCategory category;

			Error error = CategoriesHandler.GetCategoryById(CategoryId, out category);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			SetInputsFromCategory(category);
		}

		private void SetInputsFromCategory(TCategory category)
		{
			TextBoxName.Text = category.Name;
			ColorDialog.Color = category.Color;
			PanelColor.BackColor = category.Color;
			CheckBoxUseColor.Checked = category.UseColor;
			CheckBoxUsePercentage.Checked = category.UsePercentage;
			NumericPercentage.Value = category.Percentage / 100.00M;
			ComboBoxCondition.SelectedValue = category.Condition;
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private TCategory GetCategoryFromInputs()
		{
			TCategory category = new TCategory()
			{
				Id = CategoryId,
				Name = TextBoxName.Text,
				Color = ColorDialog.Color,
				UseColor = CheckBoxUseColor.Checked,
				UsePercentage = CheckBoxUsePercentage.Checked,
				Percentage = (int)(NumericPercentage.Value * 100),
				Condition = (BDBTypeLogicalOperator)ComboBoxCondition.SelectedValue,
			};

			return category;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			TCategory category = GetCategoryFromInputs();

			Error error = CategoriesHandler.SaveCategory(category, AccessMode == FAccessMode.Update);

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

		private void CheckBoxUseColor_CheckedChanged(object sender, EventArgs e)
		{
			PanelColor.Enabled = CheckBoxUseColor.Checked;
		}
	}
}
