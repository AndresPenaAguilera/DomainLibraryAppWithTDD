using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Test
{
    [TestClass]
    public class CheckoutTest : FactoryTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            Cart aCart = EmptyCart();

            var ex = Assert.ThrowsException<Exception>(() => new Ckeckout(aCart));
            Assert.AreEqual("El carro debe tener productos", ex.Message);
        }

        [TestMethod]
        public void MyTestMethod02()
        {
            Cart aCart = EmptyCart();

            // Assert.AreEqual();
        }
    }
}
