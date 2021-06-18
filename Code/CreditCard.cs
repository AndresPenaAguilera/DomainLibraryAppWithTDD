using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public class CreditCard
    {
        public int expirationMonth { get; private set; }
        public int expirationYear { get; private set; }

        public CreditCard(int expirationMonth, int expirationYear)
        {
            this.expirationMonth = expirationMonth;
            this.expirationYear = expirationYear;
        }
    }
}
