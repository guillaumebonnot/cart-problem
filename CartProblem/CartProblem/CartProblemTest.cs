using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CartProblem
{
	[TestClass]
	public class CartProblemTest
	{
        // COUPON TYPE
        // NextItemCoupon
        //  - Take N% off each individual item in the cart
        // TotalDiscountCoupon
        //  - Take P% off the next item in the cart
        // SpecialItemOfGivenTypeCoupon
        //  - Take $D off your Nth item of type T

        [TestMethod]
	    public void Test1()
	    {
	        var cart = CreateCart();
	        // Coupon: Take 10 % off your next item
	        cart.Add(CreateNextItemCoupon(10));
	        // $10 postcard sorter 
	        cart.Add(CreateItem(ItemType.PostcardSorter, 10));
	        // $20 stationery organizer
	        cart.Add(CreateItem(ItemType.StationnaryOrganizer, 20));

	        // Total = $29
	        Assert.AreEqual(29m, cart.GetTotalPrice());
	    }

	    [TestMethod]
		public void Test2()
	    {
            var cart = CreateCart();
	        // $10 postcard sorter
			cart.Add(CreateItem(ItemType.PostcardSorter, 10));
	        // Coupon: Take 10 % off your next item
            cart.Add(CreateNextItemCoupon(10));
	        // $20 stationery organizer
            cart.Add(CreateItem(ItemType.StationnaryOrganizer, 20));

	        // Total = $28
            Assert.AreEqual(28m, cart.GetTotalPrice());
		}

		[TestMethod]
		public void Test3()
		{
            var cart = CreateCart();
		    // $10 postcard sorter
			cart.Add(CreateItem(ItemType.PostcardSorter, 10));
		    // Coupon: Take $2 off your 2nd postcard sorter
			cart.Add(CreateSpecialItemOfGivenTypeCoupon(2, 2, ItemType.PostcardSorter));
		    // Coupon: 25 % off each individual item
			cart.Add(CreateTotalDiscountCoupon(25));
		    // Coupon: Take 10 % off the next item in the cart
			cart.Add(CreateNextItemCoupon(10));
		    // $10 postcard sorter
			cart.Add(CreateItem(ItemType.PostcardSorter, 10));

		    // Total = ($10 * 75 %) +(($10 - $2) *75 % *90 %) = $7.50 + $5.40 = $12.90
			Assert.AreEqual(12.9m, cart.GetTotalPrice());
		}
	}
}
