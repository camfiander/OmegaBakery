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
        //public IProduct Product { get; }
        public double Subtotal { get; }

        public string Render();

        public ProductType ProductType { get; }

    }
}
