using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptCalculator.Tax;

namespace ReceiptCalculatorTest.Tax
{
	[TestClass]
	public class TaxRateTest
	{
		[TestMethod]
		public void CalculateTax_BasicSalesTaxRate_CalculatesTaxValue()
		{
			//arrange 
			ITaxRate basicRate = new BasicSalesTaxRate();
			double price = 1.28;
			double expectedTaxValue = price * basicRate.TaxRate;

			//act
			double actualTaxValue = basicRate.CalculateTax(price);

			//assert
			Assert.AreEqual(expectedTaxValue, actualTaxValue, "Basic sales tax incorrectly calculated");
		}

		[TestMethod]
		public void CalculateTax_ImpotSalesTaxRate_CalculatesTaxValue()
		{
			//arrange 
			ITaxRate importRate = new ImportSalesTaxRate();
			double price = 12.37;
			double expectedTaxValue = price * importRate.TaxRate;

			//act
			double actualTaxValue = importRate.CalculateTax(price);

			//assert
			Assert.AreEqual(expectedTaxValue, actualTaxValue, "Import sales tax incorrectly calculated");
		}

		[TestMethod]
		public void CalculateTax_ExemptSalesTaxRate_CalculatesTaxValue()
		{
			//arrange 
			ITaxRate exepmtRate = new ExemptSalesTaxRate();
			double price = 12.37;
			double expectedTaxValue = price * exepmtRate.TaxRate;

			//act
			double actualTaxValue = exepmtRate.CalculateTax(price);

			//assert
			Assert.AreEqual(expectedTaxValue, actualTaxValue, "Exempt sales tax incorrectly calculated");
		}
	}
}
