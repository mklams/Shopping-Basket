using System;
using ReceiptCalculator.Inventory;

namespace ReceiptCalculator.Reports
{
	/// <summary>
	/// Generates a report to show the entire contents of a shopping basket
	/// </summary>
	public class ShoppingBasketReport : ReportBase
	{
		private ShoppingBasket _basket;

		public ShoppingBasketReport(ShoppingBasket basket)
		{
			_basket = basket;
		}

		/// <summary>
		/// Displays the entire contents of a shopping basket to the console along 
		/// with the total sales tax and total cost of the basket
		/// </summary>
		public override void DisplayReport()
		{
			Console.WriteLine(_basket.Name + ":");
			foreach (ShoppingBasketItem item in _basket.Items)
			{
				ShoppingBasketItemReport productReport = new ShoppingBasketItemReport(item);
				productReport.DisplayReport();
			}
			Console.WriteLine("Sales Taxes: " + FormatPrice(_basket.TotalTax));
			Console.WriteLine("Total: " + FormatPrice(_basket.TotalCost));
			Console.WriteLine();
		}

		public ShoppingBasket Basket
		{
			get { return _basket; }
		}
	}
}
