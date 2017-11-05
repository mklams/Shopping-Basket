namespace ReceiptCalculator.Inventory
{
	/// <summary>
	/// Represents a single item a user could purchase
	/// </summary>
	public class Product
	{
		private string _name;
		private double _price;
		private ProductType _type;

		/// <summary>
		/// Creates a product and assigns it a product type of other
		/// </summary>
		/// <param name="name">The name of the product</param>
		/// <param name="price">the price of the product</param>
		public Product(string name, double price) : this(name, price, ProductType.Other) { }

		public Product(string name, double price, ProductType type)
		{
			_name = name;
			_price = price;
			_type = type;
		}

		public string Name
		{
			get { return _name; }
		}

		public double Price
		{
			get { return _price; }
		}

		public ProductType Type
		{
			get { return _type; }
		}
	}
}
