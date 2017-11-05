using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptCalculator.Inventory;
using ReceiptCalculator.Tax;

namespace ReceiptCalculatorTest.Inventory
{
	[TestClass]
	public class ShoppingBasketItemTest
	{
		[TestMethod]
		public void CalculateSingleTax_WithBasicTaxAndRoundingRule_CalculatesTaxValue()
		{
			//arrange
			double price = 1.5;
			ShoppingBasketItem item = new ShoppingBasketItem(new Product("test", price));
			double expectedTax = new RoundingTaxRule().ApplyTaxRule(new BasicSalesTaxRate().CalculateTax(price));

			//act
			double actualTax = item.CalculateSingleItemTax();

			//assert
			Assert.AreEqual(expectedTax, actualTax, "Single item tax incorrectly calculated for item with basic tax rate");
		}

		[TestMethod]
		public void CalculateSingleTax_WithExemptTaxAndRoundingRule_CalculatesTaxValue()
		{
			//arrange
			double price = 1.5;
			ShoppingBasketItem item = new ShoppingBasketItem(new Product("test", price, ProductType.Medical));
			double expectedTax = new RoundingTaxRule().ApplyTaxRule(new ExemptSalesTaxRate().CalculateTax(price));

			//act
			double actualTax = item.CalculateSingleItemTax();

			//assert
			Assert.AreEqual(expectedTax, actualTax, "Single item tax incorrectly calculated for item with exempt tax rate");
		}

		[TestMethod]
		public void CalculateSingleTax_WithImportTaxAndBasicTaxAndRoundingRule_CalculatesTaxValue()
		{
			//arrange
			double price = 12.85;
			ShoppingBasketItem item = new ShoppingBasketItem(new Product("test", price), true);
			double expectedTax = (new RoundingTaxRule().ApplyTaxRule(new BasicSalesTaxRate().CalculateTax(price))) + (new RoundingTaxRule().ApplyTaxRule(new ImportSalesTaxRate().CalculateTax(price)));

			//act
			double actualTax = item.CalculateSingleItemTax();

			//assert
			Assert.AreEqual(expectedTax, actualTax, "Single item tax incorrectly calculated for item with import and basic tax rate");
		}

		[TestMethod]
		public void CalculateSingleTax_WithImportTaxAndExemptTaxAndRoundingRule_CalculatesTaxValue()
		{
			//arrange
			double price = 100.99;
			ShoppingBasketItem item = new ShoppingBasketItem(new Product("test", price, ProductType.Food), true);
			double expectedTax = (new RoundingTaxRule().ApplyTaxRule(new ExemptSalesTaxRate().CalculateTax(price))) + (new RoundingTaxRule().ApplyTaxRule(new ImportSalesTaxRate().CalculateTax(price)));

			//act
			double actualTax = item.CalculateSingleItemTax();

			//assert
			Assert.AreEqual(expectedTax, actualTax, "Single item tax incorrectly calculated for item with import and exempt tax rate");
		}

		[TestMethod]
		public void CalculateTotalTax_WithOneItem_CalculatesTaxValue()
		{
			//arrange
			double price = 1.5;
			int quantity = 1;
			ShoppingBasketItem item = new ShoppingBasketItem(new Product("test", price), quantity);
			double expectedTax = item.CalculateSingleItemTax() * quantity;

			//act
			double actualTax = item.CalculateTotalTax();

			//assert
			Assert.AreEqual(expectedTax, actualTax, "total tax incorrectly calculated for item with quantity of 1");
		}

		[TestMethod]
		public void CalculateTotalTax_WithMultipleItems_CalculatesTaxValue()
		{
			//arrange
			double price = 45.35;
			int quantity = 4;
			ShoppingBasketItem item = new ShoppingBasketItem(new Product("test", price), quantity);
			double expectedTax = item.CalculateSingleItemTax() * quantity;

			//act
			double actualTax = item.CalculateTotalTax();

			//assert
			Assert.AreEqual(expectedTax, actualTax, "total tax incorrectly calculated for item with quantity of 4");
		}

		[TestMethod]
		public void CalculateTotalCost_WithMultipleItems_CalculatesTotalCost()
		{
			//arrange
			double price = 12.5;
			int quantity = 3;
			ShoppingBasketItem item = new ShoppingBasketItem(new Product("test", price), quantity);
			double expectedTax = (item.CalculateSingleItemTax() + price) * quantity;

			//act
			double actualTax = item.CalculateTotalCost();

			//assert
			Assert.AreEqual(expectedTax, actualTax, "total cost incorrectly calculated for item with quantity of 3");
		}
	}
}
