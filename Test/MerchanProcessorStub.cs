using Code;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class MerchanProcessorStub : IMerchanProcessor
    {
        private Action<double, CreditCard> aActionDebit;
        public MerchanProcessorStub(Action<double, CreditCard> action)
        {
            aActionDebit = action;
        }
        public void Debit(double aAmount, CreditCard aCreditCard)
        {
            aActionDebit.Invoke(aAmount, aCreditCard);
        }
    }
}
