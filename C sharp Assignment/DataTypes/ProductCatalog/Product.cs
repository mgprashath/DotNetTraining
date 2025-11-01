using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog
{
    public class Product
    {
        public string ProductCode { get; private set; } = Guid.NewGuid().ToString();
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
