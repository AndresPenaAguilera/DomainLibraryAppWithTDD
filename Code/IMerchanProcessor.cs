using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public interface IMerchanProcessor
    {
        void Debit(double aAmount, CreditCard aCreditCard);
    }
}
