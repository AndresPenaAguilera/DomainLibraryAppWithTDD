using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public class Cashier
    {
        public const string MESSAGE_EMPTY_CART = "The cart cannot be empty.";
        private Cart aCart;
        private CreditCard aCreditCard;
        IMerchanProcessor aMerchanProcessor;

        public Cashier(Cart aCart, CreditCard aCreditCard, IMerchanProcessor MerchanProcessor)
        {
            AsserValidCart(aCart);
            AssertExpirationDateCreditCard(aCreditCard);

            this.aCart = aCart;
            this.aCreditCard = aCreditCard;
            aMerchanProcessor = MerchanProcessor;
        }

        private static void AssertExpirationDateCreditCard(CreditCard aCreditCard)
        {
            if (aCreditCard.expirationYear < DateTime.Now.Year)
                throw new Exception("The credit card has expired.");

            if (aCreditCard.expirationMonth < DateTime.Now.Month && aCreditCard.expirationYear <= DateTime.Now.Year)
                throw new Exception("The credit card has expired.");
        }

        public double Checkout()
        {
            double amount = aCart.CalutateTotalCosts();
            aMerchanProcessor.Debit(amount, aCreditCard);
            return amount;
        }

        private void AsserValidCart(Cart aCart)
        {
            if (aCart.Count() == 0)
                throw new Exception(MESSAGE_EMPTY_CART);
        }
    }
}
