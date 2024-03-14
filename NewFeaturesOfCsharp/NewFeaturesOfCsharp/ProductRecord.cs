using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesOfCsharp
{
    public record ProductRecord(int Id, string Name, decimal? Price)
    {
        //public int Id { get; init; }
        //public string Name { get; init; }
        //public decimal Price { get; init; }

    }

    public class ProductClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
