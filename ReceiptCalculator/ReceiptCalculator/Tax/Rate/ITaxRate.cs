namespace ReceiptCalculator.Tax
{
	/// <summary>
	/// Inteface to define a tax rate to be applied to an item
	/// </summary>
	public interface ITaxRate
	{
		double TaxRate { get; }

		double CalculateTax(double price);
	}
}
