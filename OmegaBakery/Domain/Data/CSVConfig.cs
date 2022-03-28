using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Data
{
    internal class CSVConfig
    {
        public string Path { get; set; }
        public string BInHouseFileName { get; set; }
        public string BOutsideFileName { get; set; }

        public string ProductStockFileName { get; set; }

        public CSVConfig(string path, string username, string password, string stock)
        {
            Path = path;
            BInHouseFileName = username;
            BOutsideFileName = password;
            ProductStockFileName = stock;
        }
        public CSVConfig()
        {
            Path = String.Empty;
            BInHouseFileName = string.Empty;
            BOutsideFileName = string.Empty;
            ProductStockFileName = string.Empty;
        }
    }
}
