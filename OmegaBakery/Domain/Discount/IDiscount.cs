using OmegaBakery.Domain.Order;
using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Discount
{
    internal interface IDiscount 
    {
        /// <summary>
        /// Determines if discount is applicable
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if the Discount is applicable for the line item, otherwise false</returns>
        public bool isDiscounted(List<ProductLineItem> items);

        /// <summary>
        /// Creates new Line Item with discounted subtotal
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Line item with discount applied</returns>
        //public DiscountedItem apply(LineItem item);
        public double getDiscountSubtotal(List<ProductLineItem> items);
        
        
    }
}
