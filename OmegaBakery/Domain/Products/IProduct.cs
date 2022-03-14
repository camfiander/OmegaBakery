using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    public interface IProduct : IEquatable<IProduct>
    {
        public int ProductId { get; }
        public string Name { get; }
        public string Description { get; }
        public double BasePrice { get; }

        public string Render();

    }
}
