using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain
{
    internal class ProductLineItem : ILineItem
    {
        private int count;
        private IProduct product;
        public int Count => count;

        public IProduct Product => product;

        public double Subtotal 
        { 
            get {
                return Count * Product.BasePrice;
            } 
        }

        public ProductLineItem(IProduct product, int count)
        {
            this.product = product;
            this.count = count;
        }
    }


}

