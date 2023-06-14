using CsvHelper;
using CsvTest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTest.Csv
{
    internal class CsvService
    {
        internal void Export<T>(IEnumerable<T> data, string path)
        {
            using(StreamWriter streamWriter = new StreamWriter(path))
            {
                using(CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(data);
                }
            }
        }

        internal IEnumerable<T> Import<T>(string csvFilePath)
        {
            using(StreamReader streamReader = new StreamReader(csvFilePath))
            {
                using(CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<FlatMap<ExampleModel>>();
                    var data = csvReader.GetRecords<ExampleModel>().ToList();
                    return data as IEnumerable<T>;
                }
            }
        }
    }
}
