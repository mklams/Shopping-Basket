using System.Collections.Generic;

namespace ReceiptCalculator.Inventory
{
	/// <summary>
	/// Represents a group of items that a customer is planning to purchase 
	/// </summary>
	public class ShoppingBasket
	{
		private List<ShoppingBasketItem> _items;
		private string _name;
		private double _totalTax;
		private double _totalCost;

		/// <summary>
		/// Creates a shopping basket and give it a default name of "Shopping Basket"
		/// </summary>
		public ShoppingBasket() : this("Shopping Basket") { }

		public ShoppingBasket(string name)
		{
			_name = name;
			_items = new List<ShoppingBasketItem>();
		}

		/// <summary>
		/// Adds a single item to the shopping basket 
		/// and update the total tax and total cost of the shopping basket
		/// </summary>
		/// <param name="item">item to be added to the shopping basket</param>
		public void AddItem(ShoppingBasketItem item)
		{
			_items.Add(item);
			UpdateTotalTax(item.CalculateTotalTax());
			UpdateTotalCost(item.CalculateTotalCost());
		}

		private void UpdateTotalTax(double tax)
		{
			_totalTax += tax;
		}

		private void UpdateTotalCost(double cost)
		{
			_totalCost += cost;
		}

		public List<ShoppingBasketItem> Items
		{
			get { return _items; }
		}

		public double TotalTax
		{
			get { return _totalTax; }
		}

		public double TotalCost
		{
			get { return _totalCost; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
	}
}
