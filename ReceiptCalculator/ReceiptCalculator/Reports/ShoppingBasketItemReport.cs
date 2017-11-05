using System;
using ReceiptCalculator.Inventory;

namespace ReceiptCalculator.Reports
{
	/// <summary>
	/// Creates a report to show the details of a single item in the shopping basket
	/// </summary>
	public class ShoppingBasketItemReport : ReportBase
	{
		private ShoppingBasketItem _item;

		public ShoppingBasketItemReport(ShoppingBasketItem item)
		{
			_item = item;
		}

		/// <summary>
		/// Displays the details of a single item to the console.
		/// </summary>
		public override void DisplayReport()
		{
			Console.WriteLine(string.Format("{0} {1} at {2}", _item.Quantity, GetItemDisplayName(), FormatPrice(_item.CalculateTotalCost())));
		}

		/// <summary>
		/// Generates the name of the item. Adds "imported" to the name if it is an imported item.
		/// </summary>
		/// <returns>The name to display for the item</returns>
		public string GetItemDisplayName()
		{
			if (_item.IsImported)
			{
				return "imported " + _item.Product.Name;
			}

			return _item.Product.Name;
		}

		public ShoppingBasketItem Item
		{
			get { return _item; }
		}
	}
}
