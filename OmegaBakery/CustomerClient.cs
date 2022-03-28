using OmegaBakery.Domain.Order;
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
            Order customerOrder = new Order();
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
                    var famNo = (choiceNum / 1000) - 1;
                    choiceNum %= 1000;
                    if (choiceNum >= 0 && famNo >= 0)
                    {
                        IProduct selectedProduct = productFamilies[famNo].Products[choiceNum];
                        int productStock = ProductStockManager.getInstance().getStockCount(selectedProduct);
                        Console.Write("How many would you like? (in stock: " + productStock + "): ");
                        choice = Console.ReadLine();
                        if (int.TryParse(choice, out choiceNum))
                        {
                            if (ProductStockManager.getInstance().sellStock(selectedProduct, choiceNum))
                            {
                                customerOrder.AddLineItem(new ProductLineItem(selectedProduct, choiceNum));
                                Console.WriteLine($"You've added {choiceNum} {selectedProduct.Name}(s) to your cart.");
                                Console.WriteLine("Would you like to continue shopping?");
                                Console.WriteLine("1 - Continue shopping");
                                Console.WriteLine("2 - Go to cart");
                                Console.Write("Choice: ");
                                choice = Console.ReadLine();
                                if (int.TryParse(choice, out choiceNum))
                                {
                                    if(choiceNum == 2)
                                    {
                                        RenderCart:
                                        Console.WriteLine(customerOrder.Render());
                                        Console.WriteLine("1 - Update counts");
                                        Console.WriteLine("2 - Confirm Order");
                                        Console.Write("Choice: ");
                                        choice = Console.ReadLine();
                                        if (int.TryParse(choice, out choiceNum))
                                        {
                                            Console.Write("Product Name: ");
                                            choice = Console.ReadLine();
                                            //Get product by name
                                            IProduct? productToUpdate = productFamilies
                                                .Select(x => x.Products
                                                    .Where(x => 
                                                        x.Name.ToLower() == choice.Trim().ToLower())
                                                    .FirstOrDefault())
                                                .FirstOrDefault();

                                            if(productToUpdate != null)
                                            {
                                                //Bad product name
                                            }

                                            Console.Write("New Count: ");
                                            choice = Console.ReadLine();
                                            if (int.TryParse(choice, out choiceNum))
                                            {
                                                if(choiceNum > 0)
                                                {
                                                    customerOrder.updateCount(productToUpdate, choiceNum);
                                                    goto RenderCart;
                                                }
                                            }
                                            
                                        }
                                    }
                                }

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
