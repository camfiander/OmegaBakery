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

        public string Name { get; set; }

        /// <summary>
        /// Determines if discount is applicable
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if the Discount is applicable for the line item, otherwise false</returns>
        public bool isDiscounted(ILineItem item);

        /// <summary>
        /// Creates new Line Item with discounted subtotal
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Price reduction (in negative $) for applied discount</returns>
        public double getDiscountSubtotal(ILineItem item);
        /// <summary>
        /// Creates new Line Item with discounted subtotal
        /// </summary>
        /// <param name="item"></param>
        /// <param name="baseSubtotal">Subtotal from which the discount should be based</param>
        /// <returns>Price reduction (in negative $) for applied discount</returns>
        public double getDiscountSubtotal(ILineItem item,double baseSubtotal);


    }
}
