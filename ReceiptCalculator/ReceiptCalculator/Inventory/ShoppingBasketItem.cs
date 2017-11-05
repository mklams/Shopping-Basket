using System.Collections.Generic;
using ReceiptCalculator.Tax;

namespace ReceiptCalculator.Inventory
{
	/// <summary>
	/// Represents an item that can be added to a shopping basket. 
	/// Handles calculating tax and total cost for the item.
	/// </summary>
	public class ShoppingBasketItem
	{

		private Product _product;
		private int _quantity;
		private List<ITaxRate> _appliedTaxs;
		private List<ITaxRule> _taxRules;
		private bool _isImported;

		/// <summary>
		/// Creates a shopping basket item with a quantity of 1
		/// </summary>
		/// <param name="product">The product being bought</param>
		/// <param name="isImported">If the product is imported</param>
		public ShoppingBasketItem(Product product, bool isImported) : this(product, 1, isImported) { }

		/// <summary>
		/// Creates a shopping basket item that is not imported
		/// </summary>
		/// <param name="product">The product being bought</param>
		/// <param name="quantity">The amount of the items being bought</param>
		public ShoppingBasketItem(Product product, int quantity) : this(product, quantity, false) { }

		/// <summary>
		/// Creats a shopping basket item with a quantity of 1 that is not imported
		/// </summary>
		/// <param name="product">The product being bought</param>
		public ShoppingBasketItem(Product product) : this(product, 1, false) { }

		public ShoppingBasketItem(Product product, int quantity, bool isImported)
		{
			_product = product;
			_quantity = quantity;
			_isImported = isImported;
			_appliedTaxs = new TaxRateFactory().CreateTaxRates(this);
			_taxRules = new TaxRuleFactory().CreateTaxRules();
		}

		/// <summary>
		/// Calculates the total cost of item factoring in the quantity
		/// </summary>
		/// <returns>Total cost based of entire quantity of item</returns>
		public double CalculateTotalCost()
		{
			double singleItemCost = _product.Price + CalculateSingleItemTax();
			return singleItemCost * _quantity;
		}

		/// <summary>
		/// Calculates the total tax that will be applied to the item factoring in the quantity
		/// </summary>
		/// <returns>The tax that will be applied at checkout</returns>
		public double CalculateTotalTax()
		{
			return CalculateSingleItemTax() * _quantity;
		}

		/// <summary>
		/// Calculates the tax for a single item
		/// </summary>
		/// <returns>The tax that will be applied to an individual item</returns>
		public double CalculateSingleItemTax()
		{
			double itemTax = 0.0;
			foreach (ITaxRate taxRate in _appliedTaxs)
			{
				itemTax += ApplyTaxRules(taxRate.CalculateTax(_product.Price));
			}
			return itemTax;
		}

		/// <summary>
		/// Applies the list of tax rules for the item to the given tax value
		/// </summary>
		/// <param name="tax">Tax to apply the tax rules to</param>
		/// <returns>The value of the tax after all rules are applied</returns>
		public double ApplyTaxRules(double tax)
		{
			foreach (ITaxRule rule in _taxRules)
			{
				tax = rule.ApplyTaxRule(tax);
			}

			return tax;
		}

		public Product Product
		{
			get { return _product; }
		}

		public int Quantity
		{
			get { return _quantity; }
		}

		public List<ITaxRate> AppliedTaxs
		{
			get { return _appliedTaxs; }
		}

		public bool IsImported
		{
			get { return _isImported; }
		}

		public List<ITaxRule> TaxRules
		{
			get { return _taxRules; }
		}
	}
}
