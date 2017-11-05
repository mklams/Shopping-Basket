using System;

namespace ReceiptCalculator.Tax
{
	/// <summary>
	/// Tax rule that rounds tax to up to the nearest factor of 0.05
	/// </summary>
	public class RoundingTaxRule : ITaxRule
	{
		/// <summary>
		/// Rounds the tax value to the next highest factor of 0.05
		/// </summary>
		/// <param name="tax">The tax value to apply the rule to</param>
		/// <returns>The value of the tax after applying the rule</returns>
		public double ApplyTaxRule(double tax)
		{
			return Math.Ceiling(tax * 20) / 20;
		}
	}
}
