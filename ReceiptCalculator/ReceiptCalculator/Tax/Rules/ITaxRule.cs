namespace ReceiptCalculator.Tax
{
	/// <summary>
	/// Interface for rules to be applied to a given tax value
	/// </summary>
	public interface ITaxRule
	{
		/// <summary>
		/// Applies tax rule to a given tax
		/// </summary>
		/// <param name="tax">The cost of the tax to apply the rule to</param>
		/// <returns>The cost of the tax after applying the rule to it</returns>
		double ApplyTaxRule(double tax);
	}
}
