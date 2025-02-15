using System.Data;
using Business;

namespace Household
{
	public static class Cache
	{
		public static DataSet DSCatalogs;
		public static DataTable TbAccounts;
		public static DataTable TbCategories;
		public static DataTable TbLogicalOperators;

		static Cache()
		{
			// create the tables
			TbAccounts = new DataTable("TbAccounts", "TbAccounts");
			TbAccounts.Columns.Add("id", typeof(int));
			TbAccounts.Columns.Add("name", typeof(string));
			TbAccounts.Columns.Add("balance", typeof(double));

			TbCategories = new DataTable("TbCategories", "TbCategories");
			TbCategories.Columns.Add("id", typeof(int));
			TbCategories.Columns.Add("name", typeof(string));
			TbCategories.Columns.Add("color", typeof(Color));
			TbCategories.Columns.Add("use_color", typeof(bool));

			TbLogicalOperators = new DataTable("TbLogicalOperators", "TbLogicalOperators");
			TbLogicalOperators.Columns.Add("id", typeof(BDBTypeLogicalOperator));
			TbLogicalOperators.Columns.Add("text", typeof(string));

			DSCatalogs = new DataSet();
			DSCatalogs.Tables.Add(TbAccounts);
			DSCatalogs.Tables.Add(TbCategories);
			DSCatalogs.Tables.Add(TbLogicalOperators);

			// populate the cache
			LoadAccounts();
			LoadCategories();
			LoadLogicalOperators();
		}

		public static void LoadCategories()
		{
			List<TCategory> categories;

			Error error = CategoriesHandler.GetCategories(out categories);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			TbCategories.BeginLoadData();
			TbCategories.Clear();

			DataRow row = TbCategories.NewRow();

			foreach (TCategory category in categories)
			{
				row = TbCategories.NewRow();

				row["id"] = category.Id;
				row["name"] = category.Name;
				row["color"] = category.Color;
				row["use_color"] = category.UseColor;

				TbCategories.Rows.Add(row);
			}

			TbCategories.EndLoadData();
		}

		public static void LoadAccounts()
		{
			List<TAccount> accounts;

			Error error = AccountsHandler.GetAccounts(out accounts);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			TbAccounts.BeginLoadData();
			TbAccounts.Clear();

			foreach (TAccount account in accounts)
			{
				DataRow row = TbAccounts.NewRow();

				row["id"] = account.Id;
				row["name"] = account.Name;
				row["balance"] = account.Balance / 100; // this value comes in cents

				TbAccounts.Rows.Add(row);
			}

			TbAccounts.EndLoadData();
		}
	
		public static void LoadLogicalOperators()
		{
			TbLogicalOperators.BeginLoadData();
			TbLogicalOperators.Clear();

			TbLogicalOperators.Rows.Add(BDBTypeLogicalOperator.less_than, "less than");
			TbLogicalOperators.Rows.Add(BDBTypeLogicalOperator.less_than_or_equal_to, "less than or equal to");
			TbLogicalOperators.Rows.Add(BDBTypeLogicalOperator.greater_than, "greater than");
			TbLogicalOperators.Rows.Add(BDBTypeLogicalOperator.greater_than_or_equal_to, "greater than or equal to");
			TbLogicalOperators.Rows.Add(BDBTypeLogicalOperator.equal_to, "equal to");
			TbLogicalOperators.Rows.Add(BDBTypeLogicalOperator.not_equal_to, "not_equal_to");

			TbLogicalOperators.EndLoadData();
		}
	}
}
