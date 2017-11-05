namespace ReceiptCalculator.Tax
{
	public abstract class TaxRateBase : ITaxRate
	{
		/// <summary>
		/// Calculates tax by multiplying the tax rate to the given price and 
		/// applies any tax rules to the calculated tax.
		/// </summary>
		/// <param name="price">The price to calcualte the tax for</param>
		/// <returns>The total tax for the given price after any tax rules are applied</returns>
		public virtual double CalculateTax(double price)
		{
			return price * TaxRate;
		}

		public abstract double TaxRate { get; }
	}
}
