using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Order
{
    internal class ProductLineItem : ILineItem
    {
        public int Count { get; private set; }

        public IProduct Product { get; private set; }

        public double Subtotal 
        { 
            get {
                return Count * Product.BasePrice;
            } 
        }

        public ProductType ProductType => Product.ProductType;

        public ProductLineItem(IProduct product, int count)
        {
            Product = product;
            Count = count;
        }

        public string Render()
        {
            return $"{Product.Name} | {Count} | {Subtotal.ToString("C")}";
        }

        public void UpdateCount(IProduct product, int count)
        {
            Count = count;
        }

        public bool HasProduct(IProduct product)
        {
            return Product.Equals(product);
        }
    }


}

