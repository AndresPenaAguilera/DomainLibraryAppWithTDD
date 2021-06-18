using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Test
{
    [TestClass]
    public class CheckoutTest : FactoryTest
    {
        [TestMethod]
        public void AssertCartIsNotEmpty()
        {
            Cart aCart = EmptyCart();
            CreditCard aCreditCard = ValidCreditCard();

            var ex = Assert.ThrowsException<Exception>(() => new Cashier(aCart, aCreditCard, DummyMerchanProcessor()));
            Assert.AreEqual(Cashier.MESSAGE_EMPTY_CART, ex.Message);
        }

        [TestMethod]
        public void CalculateValueToBeChargedForAProducts()
        {
            Cart aCart = EmptyCart();
            aCart.AddWithQuantity(ValidBook(), 1);

            CreditCard aCreditCard = ValidCreditCard();

            Cashier aCashier = new Cashier(aCart, aCreditCard, DummyMerchanProcessor());

            Assert.AreEqual(1000, aCashier.Checkout());
        }

        [TestMethod]
        public void CalculateValueToBeChargedForMoreThanOneProducts()
        {
            Cart aCart = EmptyCart();
            aCart.AddWithQuantity(ValidBook(), 3);
            CreditCard aCreditCard = ValidCreditCard();

            Cashier aCashier = new Cashier(aCart, aCreditCard, DummyMerchanProcessor());

            Assert.AreEqual(3000, aCashier.Checkout());
        }


        [TestMethod]
        public void TheCreditCardMustHaveAValidYear()
        {
            Cart aCart = EmptyCart();
            aCart.AddWithQuantity(ValidBook(), 3);
            CreditCard aCreditCard = ExpiredCreditCard();

            Exception exception = Assert.ThrowsException<Exception>(() => new Cashier(aCart, aCreditCard, DummyMerchanProcessor()));
            Assert.AreEqual("The credit card has expired.", exception.Message);
        }

        [TestMethod]
        public void TheCreditCardMustHaveAValidMonth()
        {
            Cart aCart = EmptyCart();
            aCart.AddWithQuantity(ValidBook(), 3);
            CreditCard aCreditCard = AnotherExpiredCreditCard();

            Exception exception = Assert.ThrowsException<Exception>(() => new Cashier(aCart, aCreditCard, DummyMerchanProcessor()));
            Assert.AreEqual("The credit card has expired.", exception.Message);
        }

        [TestMethod]
        public void Test001()
        {
            Cart aCart = EmptyCart();
            CreditCard aCreditCard = ValidCreditCard();
            aCart.AddWithQuantity(ValidBook(), 3);
            IMerchanProcessor aMerchanProcessor = new MerchanProcessorStub(
                delegate (double amount, CreditCard aCreditCard) { throw new Exception("Merchant processor unavailable."); }
                );
            Cashier aCashier = new Cashier(aCart, aCreditCard, aMerchanProcessor);


            Exception exception = Assert.ThrowsException<Exception>(() => aCashier.Checkout());
            Assert.AreEqual("Merchant processor unavailable.", exception.Message);
        }



        private CreditCard ValidCreditCard()
        {
            return new CreditCard(expirationMonth: 12, expirationYear: DateTime.Now.Year + 1);
        }

        private CreditCard ExpiredCreditCard()
        {
            return new CreditCard(expirationMonth: 12, expirationYear: 2020);
        }

        private CreditCard AnotherExpiredCreditCard()
        {
            return new CreditCard(expirationMonth: 1, expirationYear: 2021);
        }

        private IMerchanProcessor DummyMerchanProcessor()
        {
            return new MerchanProcessorDummy();
        }

    }
}
