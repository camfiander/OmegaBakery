using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    internal class BakeryOutsideProduct : IOutsideProduct
    {
        public int ProductId => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public double BasePrice => throw new NotImplementedException();

        public bool Equals(IProduct? other)
        {
            throw new NotImplementedException();
        }

        public string Render()
        {
            throw new NotImplementedException();
        }
    }
}
