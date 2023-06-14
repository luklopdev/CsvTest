using CsvTest.Csv;
using CsvTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = string.Empty;

            try
            {
                CsvService csv = new CsvService();

                var data = GetExampleData(1000);

                csvFilePath = $"{Guid.NewGuid()}.csv";
                csv.Export(data, csvFilePath);

                var importedData = csv.Import<ExampleModel>(csvFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                File.Delete(csvFilePath);
            }

            Console.ReadKey();
        }

        private static IEnumerable<ExampleModel> GetExampleData(uint count)
        {
            List<ExampleModel> result = new List<ExampleModel>();

            for(int i = 0; i < count; i++)
            {
                ExampleModel example = new ExampleModel();

                example.Id = i;
                example.CreationDate = DateTime.Now;
                example.Name = Guid.NewGuid().ToString();
                example.ReferenceModel = new ReferenceModel();
                example.ReferenceModel.Id = i;
                example.ReferenceModel.Code = Guid.NewGuid().ToString();
                example.SecondReferenceModel = new SecondReferenceModel();
                example.SecondReferenceModel.Id = i;
                example.SecondReferenceModel.Name = Guid.NewGuid().ToString();
                example.ReferenceModelId = example.ReferenceModel.Id;
                example.SecondReferenceModelId = example.SecondReferenceModel.Id;

                result.Add(example);
            }

            return result;
        }
    }
}
