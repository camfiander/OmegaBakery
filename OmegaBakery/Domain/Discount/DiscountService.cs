using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Discount
{
    internal class DiscountService
    {

        private static List<IDiscount> discounts = new List<IDiscount>()
        {
           new Discount(new PercentDiscountStrategy(0.2), "20 PERCENT OFF BAGELS", x => x.ProductType.Equals(ProductType.Bagel)),
           new Discount(new BogoDiscountStrategy(),"BOGO ALL BREAD",x => x.ProductType.Equals(ProductType.Bread))
        };

        public static List<IDiscount> GetDiscounts()
        {
            return discounts;
        }
    }
}
