using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTest.Models
{
    public class ExampleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ReferenceModelId { get; set; }
        public int? SecondReferenceModelId { get; set; }
        public ReferenceModel ReferenceModel { get; set; }
        public SecondReferenceModel SecondReferenceModel { get; set; }    
    }
}
