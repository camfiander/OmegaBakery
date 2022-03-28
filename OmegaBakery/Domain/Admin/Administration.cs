using OmegaBakery.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Admin
{
    internal class Administration
    {
        public static void Login()
        {
            //Manage();
            CheckPoint1:
            Console.Clear();
            Console.Write("Admin Login\n\n Username :");
            var username = Console.ReadLine();
            Console.Write("Password :");
            var password = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(username))
            {
                goto CheckPoint1;
            }
            if (LoginService.Validate(username, password))
            {
                Manage();
            }
        }

        private static void Manage()
        {
            CheckPoint1:
            Console.Clear();
            Console.WriteLine("Select Option\n1. Set or change login\n2. Change data source\n3. Exit");
            var choice = Console.ReadLine();
            int x = 0;
            if (string.IsNullOrWhiteSpace(choice) || !int.TryParse(choice, out x))
            {
                goto CheckPoint1;
            }
            switch (x)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Enter New Login\n\nUsername :");
                    var username = Console.ReadLine();
                    Console.Write("Password :");
                    var password = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(username))
                    {
                        goto CheckPoint1;
                    }
                    if(LoginService.SetCredentials(username, password))
                    {
                        Console.WriteLine("New Login Saved! Press Enter");
                        var ch = Console.ReadLine();
                        goto CheckPoint1;
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Set new data source(csv)\n\nPath :");
                    var path = Console.ReadLine();
                    Console.Write("Bakery In-house :");
                    var biCsv = Console.ReadLine();
                    Console.Write("Bakery Outside :");
                    var boCsv = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(path) || !string.IsNullOrWhiteSpace(biCsv) || !string.IsNullOrWhiteSpace(boCsv))
                    {
                        if(ChangeFileName(path, biCsv, boCsv))
                        {
                            Console.WriteLine("Success!!");
                            var ch = Console.ReadLine();
                            goto CheckPoint1;
                        }
                    }
                    goto CheckPoint1;
                case 3:
                    Startup.RunStartScreen();
                    break;
                default:
                    goto CheckPoint1;
            }

        }

        public static bool ChangeFileName(string path, string bihName, string boName)
        {
            var csvConfig = new CSVConfig(Path.Combine(AppService.GetBasePath(), path), bihName, boName);
            return AppService.AddOrUpdateAppSetting<CSVConfig>("CSV FileName", csvConfig);
        }
    }
}
