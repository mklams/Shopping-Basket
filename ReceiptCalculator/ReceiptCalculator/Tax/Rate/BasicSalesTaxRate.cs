namespace ReceiptCalculator.Tax
{
	/// <summary>
	/// Basic sales tax applied to items
	/// </summary>
	public class BasicSalesTaxRate : TaxRateBase
	{
		private const double _taxRate = 0.1;

		public override double TaxRate
		{
			get { return _taxRate; }
		}
	}
}
