using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    internal interface IProductFactory
    {
        public IInHouseProduct createInHouseProduct();
        public IOutsideProduct createOutsideProduct();
    }
}
