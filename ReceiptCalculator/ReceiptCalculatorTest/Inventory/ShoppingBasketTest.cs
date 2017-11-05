using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptCalculator.Inventory;

namespace ReceiptCalculatorTest.Inventory
{
	[TestClass]
	public class ShoppingBasketTest
	{
		[TestMethod]
		public void AddItem_WithNewBasket_UpdatesTotals()
		{
			//arrange
			ShoppingBasket basket = new ShoppingBasket();
			ShoppingBasketItem item = new ShoppingBasketItem(new Product("test", 5.5, ProductType.Other));
			double expetedTotalCost = item.CalculateTotalCost();
			double expectedTotalTax = item.CalculateTotalTax();

			//act
			basket.AddItem(item);

			//assert
			Assert.AreEqual(expectedTotalTax, basket.TotalTax, "Total tax not updated correctly");
			Assert.AreEqual(expetedTotalCost, basket.TotalCost, "Total cost not update correctly");
		}

		[TestMethod]
		public void AddItem_WithMultipleItems_UpdatesTotals()
		{
			//arrange
			ShoppingBasket basket = new ShoppingBasket();
			ShoppingBasketItem item1 = new ShoppingBasketItem(new Product("test", 5.5, ProductType.Other));
			ShoppingBasketItem item2 = new ShoppingBasketItem(new Product("test", 8.75, ProductType.Food));
			double expetedTotalCost = item1.CalculateTotalCost() + item2.CalculateTotalCost();
			double expectedTotalTax = item1.CalculateTotalTax() + item2.CalculateTotalTax();

			//act
			basket.AddItem(item1);
			basket.AddItem(item2);

			//assert
			Assert.AreEqual(expectedTotalTax, basket.TotalTax, "Total tax not updated correctly");
			Assert.AreEqual(expetedTotalCost, basket.TotalCost, "Total cost not update correctly");
		}
	}
}
