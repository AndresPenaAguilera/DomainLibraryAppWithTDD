using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Test
{
    [TestClass]
    public class ShoppingTest : FactoryTest
    {
        [TestMethod]
        public void ValidateEmptyCart()
        {
            var aCart = EmptyCart();

            Assert.IsFalse(aCart.Any());
        }

        [TestMethod]
        public void addBookToCart()
        {
            var aCart = EmptyCart();
            object aIsbn = ValidBook();

            aCart.Add(aIsbn);

            Assert.IsTrue(aCart.Contains(aIsbn));
        }

        [TestMethod]
        public void AddMoreThanOneBookToCart()
        {
            var aCart = EmptyCart();
            var aIsbn = ValidBook();
            var anotherIsbn = AnotherValidBook();

            aCart.Add(aIsbn);
            aCart.Add(anotherIsbn);

            Assert.IsTrue(aCart.Contains(aIsbn));
            Assert.IsTrue(aCart.Contains(anotherIsbn));
        }

        [TestMethod]
        public void AddBookWithQuantity()
        {
            var aCart = EmptyCart();
            var aIsbn = ValidBook();
            int quantity = 3;

            aCart.AddWithQuantity(aIsbn, quantity);

            Assert.AreEqual(quantity, aCart.Count(aIsbn));
        }

        [TestMethod]
        public void GivenCatalogAddBookInvalidReturnExeption()
        {
            Cart aCart = EmptyCart();
            var aIsbn = InvalidBook();

            var exception = Assert.ThrowsException<Exception>(() => aCart.Add(aIsbn));
            Assert.AreEqual(Cart.PRODUCT_IS_NOT_IN_CATALOG, exception.Message);
        }

        [TestMethod]
        public void AssertAddBookQuantityGreaterThan0()
        {
            Cart aCart = EmptyCart();
            var aIsbn = ValidBook();

            var exception = Assert.ThrowsException<Exception>(() => aCart.AddWithQuantity(aIsbn, 0));
            Assert.AreEqual(Cart.QUANTITY_GRATER_TAN_ZERO, exception.Message);
        }

        [TestMethod]
        public void GetProductsAmount()
        {
            var aCart = EmptyCart();

            aCart.AddWithQuantity(ValidBook(), 3);
            aCart.AddWithQuantity(AnotherValidBook(), 4);

            Assert.AreEqual(3, aCart.Count(ValidBook()));
            Assert.AreEqual(4, aCart.Count(AnotherValidBook()));
            Assert.AreEqual(7, aCart.Count());
        }
    }
}
