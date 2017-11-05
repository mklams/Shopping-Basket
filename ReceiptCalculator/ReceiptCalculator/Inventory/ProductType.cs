namespace ReceiptCalculator.Inventory
{
	/// <summary>
	/// Represents the different catagories that a product can be.
	/// Used to help determine the tax rate to apply to the product.
	/// </summary>
	public enum ProductType : int
	{
		Food,
		Book,
		Medical,
		Other
	}
}
