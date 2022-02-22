using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain
{
    internal interface LineItem
    {
        public int Count { get; }
        public Product Product { get; }

        public double Subtotal { get; }

    }
}
