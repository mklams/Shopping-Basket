namespace ReceiptCalculator.Tax
{
	/// <summary>
	/// Sales tax applied to imported items
	/// </summary>
	public class ImportSalesTaxRate : TaxRateBase
	{
		private const double _taxRate = 0.05;

		public override double TaxRate
		{
			get { return _taxRate; }
		}
	}
}
