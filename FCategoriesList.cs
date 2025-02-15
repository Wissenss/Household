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
	public partial class FCategoriesList : Form
	{
		public FCategoriesList()
		{
			InitializeComponent();

			GridCategories.DataSource = Cache.DSCatalogs;
			GridCategories.DataMember = "TbCategories";
		}

		private void LoadList()
		{
			Cache.LoadCategories();
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FCategoryData category_data_dialog = new FCategoryData())
			{
				if (category_data_dialog.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private int GetSelectedCategoryId()
		{
			if (GridCategories.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = GridCategories.SelectedRows[0];

			int category_id = (int)row.Cells["id"].Value;

			return category_id;
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			int category_id = GetSelectedCategoryId();

			if (category_id != 0)
			{
				using (FCategoryData category_data_dialog = new FCategoryData())
				{
					category_data_dialog.SetAccessMode(FAccessMode.Update);
					category_data_dialog.SetCategoryId(category_id);

					if (category_data_dialog.ShowDialog() == DialogResult.OK)
					{
						LoadList();
					}
				}
			}
		}

		private void GridCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (GridCategories.Columns[e.ColumnIndex].Name == "ColorDisplay")
			{
				Color color = (Color)Cache.TbCategories.Rows[e.RowIndex]["color"];

				e.CellStyle.BackColor = color;
				e.CellStyle.SelectionBackColor = color;
			}
		}
	}
}
