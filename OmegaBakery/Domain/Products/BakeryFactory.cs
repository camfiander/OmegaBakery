using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    public class BakeryFactory : IProductFactory
    {
        public IInHouseProduct createInHouseProduct() => new BakeryInHouseProduct();

        public IOutsideProduct createOutsideProduct() => new BakeryOutsideProduct();
    }
}
