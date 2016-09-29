using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CartProblem
{
	[TestClass]
	public class CartProblemTest
	{
		[TestMethod]
		public void Test1()
		{
			var cart = CreateCart();
			cart.Add(CreateNextItemCoupon(10));
			cart.Add(CreateItem(ItemType.PostcardSorter, 10));
			cart.Add(CreateItem(ItemType.StationnaryOrganizer, 20));

			Assert.AreEqual(29m, cart.GetTotalPrice());
		}

		[TestMethod]
		public void Test2()
		{
			var cart = CreateCart();
			cart.Add(CreateItem(ItemType.PostcardSorter, 10));
			cart.Add(CreateNextItemCoupon(10));
			cart.Add(CreateItem(ItemType.StationnaryOrganizer, 20));

			Assert.AreEqual(28m, cart.GetTotalPrice());
		}

		[TestMethod]
		public void Test3()
		{
			var cart = CreateCart();
			cart.Add(CreateItem(ItemType.PostcardSorter, 10));
			cart.Add(CreateSpecialItemOfGivenTypeCoupon(2, 2, ItemType.PostcardSorter));
			cart.Add(CreateTotalDiscountCoupon(25));
			cart.Add(CreateNextItemCoupon(10));
			cart.Add(CreateItem(ItemType.PostcardSorter, 10));

			Assert.AreEqual(12.9m, cart.GetTotalPrice());
		}
	}
}
