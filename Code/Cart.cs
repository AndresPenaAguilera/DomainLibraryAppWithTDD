using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
    public class Cart
    {
        public const string PRODUCT_IS_NOT_IN_CATALOG = "Product is not in catalog";
        public const string QUANTITY_GRATER_TAN_ZERO = "Quantity greater than 0";

        private List<object> products = new List<object>();
        private List<object> _catalog { get; }
        public Cart(List<object> catalog)
        {
            _catalog = catalog;
        }

        public bool Any()
        {
            return products.Any();
        }

        public void Add(object aIsbn)
        {
            AddWithQuantity(aIsbn, 1);
        }

        public void AddWithQuantity(object aIsbn, int quantity)
        {
            AssertValidProduct(aIsbn);
            AssertQuantitygreaterThanZero(quantity);

            for (int i = 1; i <= quantity; ++i)
            {
                products.Add(aIsbn);
            }
        }

        public bool Contains(object aIsbn)
        {
            return products.Contains(aIsbn);
        }

        public int Count(object aIsbn)
        {
            return products.Where(x => x == aIsbn).Count();
        }

        private static void AssertQuantitygreaterThanZero(int quantity)
        {
            if (quantity <= 0)
                throw new Exception(QUANTITY_GRATER_TAN_ZERO);
        }

        private void AssertValidProduct(object aIsbn)
        {
            if (!_catalog.Contains(aIsbn))
            {
                throw new Exception(PRODUCT_IS_NOT_IN_CATALOG);
            }
        }

        public int Count()
        {
            return products.Count();
        }
    }
}