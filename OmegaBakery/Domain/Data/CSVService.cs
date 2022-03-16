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
    internal static class CSVService
    {
        static CsvHelper.Configuration.CsvConfiguration configure = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
        };

        public static List<U> ReadCSVFile<T, U>(string location)
        {
            try
            {
                using var reader = new StreamReader(location, Encoding.Default);
                using var csv = new CsvReader((IParser)reader);
                csv.Context.RegisterClassMap<ClassMap<T>>();
                var records = csv.GetRecords<U>().ToList();
                return records;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void WriteCSVFile<U>(string path, List<U> products)
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

        public static bool ChangeFileName(string path, string bihName, string boName)
        {
            var csvConfig = new CSVConfig(Path.Combine(AppService.GetBasePath(), path), bihName, boName);
            return AppService.AddOrUpdateAppSetting<CSVConfig>("CSV FileName", csvConfig);
        }
    }
}
