using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    internal class OutsideProductFamily : ProductFamily
    {
        private List<OutsideProduct> _products;
        private string _name;

        public override List<IProduct> Products => _products.Cast<IProduct>().ToList();

        public override string Name => _name;

        public OutsideProductFamily(string name, List<OutsideProduct> products)
        {
            _name = name;
            _products = products;
        }

    }
}
