using System.Collections.Generic;

namespace ReceiptCalculator.Tax
{
	/// <summary>
	/// Determines all the tax rules to apply to a given item
	/// </summary>
	public class TaxRuleFactory
	{
		/// <summary>
		/// Create a list of all the tax rules for a given item.
		/// Currently there is only one tax rule that applies to all items so
		/// this method always reuturns that rule.
		/// </summary>
		/// <returns>List of all tax rules for item</returns>
		public List<ITaxRule> CreateTaxRules()
		{
			List<ITaxRule> rules = new List<ITaxRule>();
			rules.Add(new RoundingTaxRule());
			return rules;
		}
	}
}
