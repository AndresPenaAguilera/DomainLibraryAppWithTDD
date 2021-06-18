using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace Test
{
    [TestClass]
    public class FactoryTest
    {
        public Dictionary<object, double> Catalog()
        {
            Dictionary<object, double> catalog = new Dictionary<object, double>();
            catalog.Add(ValidBook(), 1000);
            catalog.Add(AnotherValidBook(), 2000);
            return catalog;
        }


        public Cart EmptyCart()
        {
            var catalog = Catalog();
            return new Cart(catalog);
        }

        public object InvalidBook()
        {
            return "ISBN5";
        }

        public object ValidBook()
        {
            return "ISBN1";
        }

        public object AnotherValidBook()
        {
            return "ISBN2";
        }
    }
}