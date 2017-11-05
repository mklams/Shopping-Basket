using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptCalculator.Tax;

namespace ReceiptCalculatorTest.Tax
{
	[TestClass]
	public class TaxRuleTest
	{
		[TestMethod]
		public void ApplyTaxRule_RoundingTaxRule_RoundsTaxValue()
		{
			//arrange
			ITaxRule rule = new RoundingTaxRule();
			double tax = 1.41;
			double expectedTax = 1.45;

			//act
			double actualTax = rule.ApplyTaxRule(tax);

			//assert
			Assert.AreEqual(expectedTax, actualTax, "Rounding rule did not correctly round tax");

		}

		[TestMethod]
		public void ApplyTaxRule_RoundingTaxRule_KeepsTaxValue()
		{
			//arrange
			ITaxRule rule = new RoundingTaxRule();
			double tax = 12.55;
			double expectedTax = 12.55;

			//act
			double actualTax = rule.ApplyTaxRule(tax);

			//assert
			Assert.AreEqual(expectedTax, actualTax, "Rounding rule did not correctly round tax");

		}

		[TestMethod]
		public void ApplyTaxRule_RoundingTaxRule_RoundsToNearestWholeNumber()
		{
			//arrange
			ITaxRule rule = new RoundingTaxRule();
			double tax = 1.98;
			double expectedTax = 2.00;

			//act
			double actualTax = rule.ApplyTaxRule(tax);

			//assert
			Assert.AreEqual(expectedTax, actualTax, "Rounding rule did not correctly round tax");

		}
	}
}
