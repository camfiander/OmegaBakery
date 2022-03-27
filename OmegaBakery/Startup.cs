using OmegaBakery.Domain.Admin;

namespace OmegaBakery
{
    internal static class Startup
    {
        public static void InitConfig()
        {
            AppService.InitConfig();
        }
        public static void RunStartScreen()
        {
            Console.WriteLine("Welcome to Omega Bakery!");

            Initial:
            Console.WriteLine("Choose your Option\n1. Shop\n2. Admin login");
            string? choice = Console.ReadLine();
            int x = 0;
            if (String.IsNullOrWhiteSpace(choice) || !int.TryParse(choice, out x))
            {
                goto Initial;
            }
            switch (x)
            {
                case 1:
                    CustomerClient.run();
                    break;
                case 2:
                    Administration.Login();
                    break;
            }
        }
        public static void StartupApp()
        {
            InitConfig();
            RunStartScreen();
        }
    }
}
