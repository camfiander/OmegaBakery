using OmegaBakery.Domain.Discount;
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
        //public void Checkout()
        //{
        //    foreach(ILineItem item in Order.LineItems)
        //    {
                
        //    }
        //}

        public void ApplyDiscounts() 
        {
            List<IDiscount> discounts = DiscountService.GetDiscounts();
            foreach(IDiscount discount in discounts)
            {
                //Check all items for applicable discount
                //Replace ILineItems with DiscountedLineItems if discount is applicable
            }
        }


    }
}
