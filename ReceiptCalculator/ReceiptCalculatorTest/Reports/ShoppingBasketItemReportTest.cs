using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptCalculator.Inventory;
using ReceiptCalculator.Reports;

namespace ReceiptCalculatorTest.Reports
{
	[TestClass]
	public class ShoppingBasketItemReportTest
	{
		[TestMethod]
		public void GetItemDisplayName_WithImportedItem_DisplaysProperName()
		{
			//arrange
			ShoppingBasketItem item = new ShoppingBasketItem(new Product("Test import product", 100), true);
			ShoppingBasketItemReport report = new ShoppingBasketItemReport(item);
			string expectedName = "imported " + item.Product.Name;

			//act
			string actualName = report.GetItemDisplayName();

			//assert
			Assert.AreEqual(expectedName, actualName, "Display name is incorrect for imported item");
		}

		[TestMethod]
		public void GetItemDisplayName_WithNonImportItem_DisplaysProperName()
		{
			//arrange
			ShoppingBasketItem item = new ShoppingBasketItem(new Product("Test product", 100));
			ShoppingBasketItemReport report = new ShoppingBasketItemReport(item);
			string expectedName = item.Product.Name;

			//act
			string actualName = report.GetItemDisplayName();

			//assert
			Assert.AreEqual(expectedName, actualName, "Display name is incorrect for imported item");
		}
	}
}
