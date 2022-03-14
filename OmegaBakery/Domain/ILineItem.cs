using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain
{
    internal interface ILineItem
    {
        public int Count { get; }
        public IProduct Product { get; }

        public double Subtotal { get; }

    }
}
