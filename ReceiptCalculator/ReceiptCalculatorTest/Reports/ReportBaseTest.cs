using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptCalculator.Reports;

namespace ReceiptCalculatorTest.Reports
{
	[TestClass]
	public class ReportBaseTest
	{
		[TestMethod]
		public void FormatPrice_WithWholeNumberPrice_AddsDecimals()
		{
			//arrange
			MockReport report = new MockReport();
			double price = 13;
			string expectedPrice = "13.00";

			//act
			string actualPrice = report.FormatPrice(price);

			//assert
			Assert.AreEqual(expectedPrice, actualPrice, "Decimal places not correctly added to price");
		}

		[TestMethod]
		public void FormatPrice_WithSingleDecimalPlace_AddsDecimal()
		{
			//arrange
			MockReport report = new MockReport();
			double price = 115.1;
			string expectedPrice = "115.10";

			//act
			string actualPrice = report.FormatPrice(price);

			//assert
			Assert.AreEqual(expectedPrice, actualPrice, "Decimal places not correctly added to price");
		}

		[TestMethod]
		public void FormatPrice_WithExtraDecimalPlace_RemovesDecimal()
		{
			//arrange
			MockReport report = new MockReport();
			double price = 8.111;
			string expectedPrice = "8.11";

			//act
			string actualPrice = report.FormatPrice(price);

			//assert
			Assert.AreEqual(expectedPrice, actualPrice, "Decimal places not correctly remove from price");
		}

		public class MockReport : ReportBase
		{
			public override void DisplayReport()
			{
			}
		}
	}
}
