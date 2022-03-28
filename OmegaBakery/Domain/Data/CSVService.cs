using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using OmegaBakery.Domain.Products;

namespace OmegaBakery.Domain.Data
{
    internal class CSVService
    {
        private static CsvHelper.Configuration.CsvConfiguration configure = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
        };

        public List<U> ReadCSVFile<T, U>(string location) where T : ClassMap<U>
        {
            try
            {
                using var reader = new StreamReader(location, Encoding.Default);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Context.RegisterClassMap<T>();
                var records = csv.GetRecords<U>().ToList();
                return records;
            }
            catch (Exception e)
            {
                Console.WriteLine("System Error!\n", e);
                return new List<U>();
            }
        }
        public void WriteCSVFile<U>(string path, List<U> products)
        {
            using StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true));
            using CsvWriter cw = new CsvWriter(sw, configure);
            cw.WriteHeader<U>();
            cw.NextRecord();
            foreach (U product in products)
            {
                cw.WriteRecord<U>(product);
                cw.NextRecord();
            }
        }
    }
}
