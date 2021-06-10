using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class ShoppingCartUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<object> car = Empty();
            Assert.IsFalse(car.Any());
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<object> car = Empty();
            car.Add("Book1");
            Assert.IsTrue(car.Any());
        }

       

        private static List<object> Empty()
        {
            return new List<object>();
        }
    }
}
