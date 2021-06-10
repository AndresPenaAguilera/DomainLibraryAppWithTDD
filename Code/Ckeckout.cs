using System;

namespace Code
{
    public class Ckeckout
    {
        private Cart aCart;

        public Ckeckout(Cart aCart)
        {
            if (aCart.Count() == 0)
                throw new Exception("El carro debe tener productos");

            this.aCart = aCart;
        }
    }
}