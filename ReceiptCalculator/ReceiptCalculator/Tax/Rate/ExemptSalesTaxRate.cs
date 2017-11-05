namespace ReceiptCalculator.Tax
{
	/// <summary>
	/// Sales tax applied to tax exempt items
	/// </summary>
	public class ExemptSalesTaxRate : TaxRateBase
	{
		private const double _taxRate = 0.0;

		public override double TaxRate
		{
			get { return _taxRate; }
		}
	}
}
