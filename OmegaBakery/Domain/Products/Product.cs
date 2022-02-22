using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    internal interface Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double BasePrice { get; set; }

    }
}
