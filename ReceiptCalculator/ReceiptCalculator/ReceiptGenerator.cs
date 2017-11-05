using System;
using ReceiptCalculator.Inventory;
using ReceiptCalculator.Reports;

namespace ReceiptCalculator
{
	public class ReceiptGenerator
	{
		static void Main(string[] args)
		{
			ShoppingBasket shoppingBasket1 = new ShoppingBasket("Shopping Basket 1");
			shoppingBasket1.AddItem(new ShoppingBasketItem(new Product("book", 12.49, ProductType.Book)));
			shoppingBasket1.AddItem(new ShoppingBasketItem(new Product("music CD", 14.99, ProductType.Other)));
			shoppingBasket1.AddItem(new ShoppingBasketItem(new Product("choclate bar", 0.85, ProductType.Food)));
			ShoppingBasketReport report1 = new ShoppingBasketReport(shoppingBasket1);
			report1.DisplayReport();

			ShoppingBasket shoppingBasket2 = new ShoppingBasket("Shopping Basket 2");
			shoppingBasket2.AddItem(new ShoppingBasketItem(new Product("box of chocolates", 10, ProductType.Food), true));
			shoppingBasket2.AddItem(new ShoppingBasketItem(new Product("bottle of perfume", 47.50, ProductType.Other), true));
			ShoppingBasketReport report2 = new ShoppingBasketReport(shoppingBasket2);
			report2.DisplayReport();

			ShoppingBasket shoppingBasket3 = new ShoppingBasket("Shopping Basket 3");
			shoppingBasket3.AddItem(new ShoppingBasketItem(new Product("bottle of perfume", 27.99, ProductType.Other), true));
			shoppingBasket3.AddItem(new ShoppingBasketItem(new Product("bottle of perfume", 18.99, ProductType.Other)));
			shoppingBasket3.AddItem(new ShoppingBasketItem(new Product("packet of headache pills", 9.75, ProductType.Medical)));
			shoppingBasket3.AddItem(new ShoppingBasketItem(new Product("box of chocolates", 11.25, ProductType.Food), true));
			ShoppingBasketReport report3 = new ShoppingBasketReport(shoppingBasket3);
			report3.DisplayReport();

			// Keep the console window open in debug mode.
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}
	}
}
