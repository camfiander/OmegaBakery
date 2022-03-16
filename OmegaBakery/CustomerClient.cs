using OmegaBakery.Domain.Products;
using OmegaBakery.Domain.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery
{
    internal class CustomerClient
    {
        public static void run()
        {
            while (true)
            {

                Console.WriteLine("Please select an item to purchase");

                List<ProductFamily> productFamilies = ProductService.GetProductFamilies();

                foreach (ProductFamily family in productFamilies)
                {
                    for (int i = 0; i < family.Products.Count; i++)
                    {
                        Console.WriteLine(i + " - " + family.Products[i].Render());
                    }

                }
                Console.Write("Product to buy: ");
                string? choice = Console.ReadLine();
                int choiceNum;
                if (choice != null && int.TryParse(choice, out choiceNum))
                {
                    if (choiceNum >= 0 && choiceNum < productFamilies[0].Products.Count)
                    {
                        IProduct selectedProduct = productFamilies[0].Products[choiceNum];
                        int productStock = ProductStockManager.getInstance().getStockCount(selectedProduct);
                        Console.Write("How many would you like? (in stock: " + productStock + "): ");
                        choice = Console.ReadLine();
                        if (int.TryParse(choice, out choiceNum))
                        {
                            if (ProductStockManager.getInstance().sellStock(selectedProduct, choiceNum))
                            {
                                Console.WriteLine("you bought em");
                            }
                            else
                            {
                                Console.WriteLine("error");
                            }
                        }
                    }
                }
            }


        }
    }
}
