using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTest.Csv
{
    internal class FlatMap<T> : ClassMap<T> where T : class
    {
        public FlatMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }

        public override void AutoMap(CultureInfo culture)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                    continue;

                Map(property.PropertyType, property).Name(property.Name);
            }
        }
    }
}
