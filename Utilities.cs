using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace Household
{
	public static class Utilities
	{
		public static int TrimOnRange(int lowest_value, int highest_value, int value)
		{
			value = Math.Max(value, lowest_value);
			value = Math.Min(value, highest_value);

			return value;
		}

		public static void ShowErrorDialog(Error error)
		{
			MessageBox.Show(Errors.GetErrorDescription(error), $"Error{(int)error}: {error.ToString()}", MessageBoxButtons.OK);
		}

		public static void ShowValidationErrorDialog(StringBuilder errors, string title = "Invalid Input")
		{
			MessageBox.Show(errors.ToString(), title, MessageBoxButtons.OK);
		}
	}
}
