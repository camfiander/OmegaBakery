using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Order
{
    internal interface ILineItem
    {
        public int Count { get; }
        public double Subtotal { get; }
        public ProductType ProductType { get; }

        public string Render();

        public void UpdateCount(IProduct product, int count);

        public bool HasProduct(IProduct product);

    }
}
