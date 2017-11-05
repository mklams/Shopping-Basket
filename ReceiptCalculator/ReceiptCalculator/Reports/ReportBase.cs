namespace ReceiptCalculator.Reports
{
	/// <summary>
	/// Base class for generating reports relating to shopping basket application
	/// </summary>
	public abstract class ReportBase
	{
		public abstract void DisplayReport();

		/// <summary>
		/// Formats a given number to only show to decimal places
		/// </summary>
		/// <param name="price">The number to properly format as a price</param>
		/// <returns>The price formatted to two decimal places</returns>
		public string FormatPrice(double price)
		{
			return string.Format("{0:0.00}", price);
		}
	}
}
