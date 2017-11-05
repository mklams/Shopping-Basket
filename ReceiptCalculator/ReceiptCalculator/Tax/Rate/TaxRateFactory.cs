using System.Collections.Generic;
using ReceiptCalculator.Inventory;

namespace ReceiptCalculator.Tax
{
	/// <summary>
	/// Determines what tax rates should be applied to the given item.
	/// </summary>
	public class TaxRateFactory
	{

		/// <summary>
		/// Creates a list of tax rates for a given item
		/// </summary>
		/// <param name="item">The item to create tax rates for</param>
		/// <returns>A list of tax rates to be applied to the item</returns>
		public List<ITaxRate> CreateTaxRates(ShoppingBasketItem item)
		{
			List<ITaxRate> taxRates = new List<ITaxRate>();

			switch (item.Product.Type)
			{
				case ProductType.Book:
				case ProductType.Food:
				case ProductType.Medical:
					taxRates.Add(new ExemptSalesTaxRate());
					break;
				case ProductType.Other:
				default:
					taxRates.Add(new BasicSalesTaxRate());
					break;
			}

			if (item.IsImported)
			{
				taxRates.Add(new ImportSalesTaxRate());
			}

			return taxRates;
		}
	}
}
