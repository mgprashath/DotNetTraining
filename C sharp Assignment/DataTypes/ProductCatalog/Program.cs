namespace ProductCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductCatalog catalog = new ProductCatalog();

            //catalog.AddProduct(new Product(19.99m, 100));
            //catalog.AddProduct(new Product(29.99m, 50));
            //catalog.AddProduct(new Product(9.99m, 200));
            //catalog.DisplayAllProducts();

            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();

            Console.WriteLine("Welcome to Product Catalog!");
            string? input;

            do
            {               
                Console.WriteLine("---------------------------");
                Console.WriteLine("");
                Console.WriteLine("Press 0 to View All Products");
                Console.WriteLine("Press 1 to Add a Product");
                Console.WriteLine("Press q to Quit Application");

                input = Console.ReadLine();

                if (input != null && input.ToLower() == "q")
                {
                    Console.WriteLine("Application shut down, Good bye!");
                    break;
                }

                switch (input)
                {
                    case "0":
                        catalog.DisplayAllProducts();
                        break;
                    case "1":
                        bool result =true;
                        do
                        {
                            Product product = new Product();

                            Console.WriteLine("Enter product price:");
                            if (decimal.TryParse(Console.ReadLine(), out decimal price))
                            {
                                product.Price = price;
                                Console.WriteLine("Enter stock quantity:");

                                if (int.TryParse(Console.ReadLine(), out int stockQuantity))
                                {                                   
                                    product.StockQuantity = stockQuantity;
                                    catalog.AddProduct(product);
                                    catalog.DisplayAllProducts();
                                    result = false;

                                }
                                else
                                {
                                    Console.WriteLine("Invalid stock quantity. Please enter a numeric value.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid price. Please enter a numeric value.");
                            }

                        } while(result);

                        break;
                }

            } while (true);
        }
    }


}