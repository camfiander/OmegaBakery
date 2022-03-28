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
                int pNo = 1;
                foreach (ProductFamily family in productFamilies)
                {
                    Console.WriteLine(family.Name);
                    for (int i = 0; i < family.Products.Count; i++)
                    {
                        Console.WriteLine((pNo*1000+i) + " - " + family.Products[i].Render());
                    }
                    pNo++;
                }
                Console.Write("Product to buy: ");
                string? choice = Console.ReadLine();
                int choiceNum;
                if (choice != null && int.TryParse(choice, out choiceNum))
                {
                    var famNo = choiceNum / 1000;
                    choiceNum -= 1000;
                    if (choiceNum >= 0 && choiceNum < productFamilies[famNo].Products.Count)
                    {
                        IProduct selectedProduct = productFamilies[famNo].Products[choiceNum];
                        int productStock = ProductStockManager.GetInstance().GetStockCount(selectedProduct);
                        Console.Write("How many would you like? (in stock: " + productStock + "): ");
                        choice = Console.ReadLine();
                        if (int.TryParse(choice, out choiceNum))
                        {
                            if (ProductStockManager.GetInstance().SellStock(selectedProduct, choiceNum))
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
