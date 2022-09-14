using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UI
{
    public static class TaxRateImporter
    {
        public static List<TaxRate>ImportTaxRates(string file)
        {
            string path = $@"..\..\..\import\{file}.csv";
            var rates = new List<TaxRate>();

            using(var reader = new StreamReader(path))
            {
                for(string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    string[] properties = line.Split(',');
                    var rate = new TaxRate
                    {
                        Lower = int.Parse(properties[0]),
                        Upper = int.Parse(properties[1]),
                        A = double.Parse(properties[2]),
                        B = double.Parse(properties[3]),
                    };
                    rates.Add(rate);
                }
            }
            return rates;
        }
    }
}
