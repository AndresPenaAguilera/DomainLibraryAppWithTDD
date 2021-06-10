using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace Test
{
    [TestClass]
    public class FactoryTest
    {
        public object AnotherValidBook()
        {
            return "ISBN2";
        }

        public List<object> Catalog()
        {
            List<object> catalog = new List<object>();
            catalog.Add(ValidBook());
            catalog.Add(AnotherValidBook());
            return catalog;
        }


        public Cart EmptyCart()
        {
            List<object> catalog = Catalog();
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
    }
}