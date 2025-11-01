using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog
{
    public class ProductCatalog
    {
        private List<Product> products = new List<Product>();
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void DisplayAllProducts()
        {
            Console.WriteLine("Product Catalog:");
            Console.WriteLine("----------------");
            Console.WriteLine("");

            foreach (var product in products)
            {
                Console.WriteLine($"Product Code: {product.ProductCode}, Price: {product.Price}, Stock: {product.StockQuantity}");
            }

            Console.WriteLine("----------------");
            Console.WriteLine("");
        }
    }
}
