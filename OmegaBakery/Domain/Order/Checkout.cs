using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Order
{
    internal class Checkout
    {
        public Order Order { get; set; }
        public void checkout()
        {
            foreach(ILineItem item in Order.LineItems)
            {
                
            }
        }
    }
}
