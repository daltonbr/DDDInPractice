using DDDInPractice.Logic;
using static DDDInPractice.Logic.Money;

namespace DDDInPractice.ConsoleUI
{
    public static class Program
    {
        private static SnackMachine Machine { get; } = new();
        
        public static void Main(string[] args)
        {
            while(true)
            {
                RenderInitialMenu();

                ReadAndProcessOptions(System.Console.ReadKey().KeyChar);
            }
        }

        private static void ReadAndProcessOptions(char input)
        {
            char inputUpper = Convert.ToChar(input.ToString().ToUpper());
            switch (inputUpper)
            {
                case '1':
                    System.Console.WriteLine(" Put 1 cent");
                    InsertMoney(OneCent);
                    break;
                case '2':
                    System.Console.WriteLine(" Put 10 cent");
                    InsertMoney(TenCent);
                    break;
                case '3':
                    System.Console.WriteLine(" Put 25 cent");
                    InsertMoney(Quarter);
                    break;
                case '4':
                    System.Console.WriteLine(" Put 1 Dollar");
                    InsertMoney(OneDollar);
                    break;
                case '5':
                    System.Console.WriteLine(" Put 5 Dollars");
                    InsertMoney(FiveDollar);
                    break;
                case '6':
                    System.Console.WriteLine(" Put 20 Dollars");
                    InsertMoney(TwentyDollar);
                    break;
                case 'R':
                    System.Console.WriteLine(" Return Money");
                    ReturnMoney();
                    break;
                case 'B':
                    System.Console.WriteLine(" Buy Snack");
                    BuySnack();
                    break;
                case 'Q':
                    System.Console.WriteLine(" Quit");
                    Environment.Exit(0);
                    break;
                default:
                    System.Console.WriteLine($"Invalid Option - {input}");
                    break;
            }
        }

        private static void InsertMoney(Money money)
        {
            Machine.InsertMoney(money);
        }

        private static void ReturnMoney()
        {
            Machine.ReturnMoney();
        }

        private static void BuySnack()
        {
            Machine.BuySnack();
        }
        
        private static void RenderOutputAndWait()
        {
            RenderMachineDetails();
            System.Console.WriteLine("");
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }

        private static void RenderMachineDetails()
        {
            System.Console.WriteLine($"Credits in current Transaction: $ {Machine.MoneyInTransaction.Amount}");
            System.Console.WriteLine($"Money Inside: $ {Machine.MoneyInside.Amount}");
        }

        private static void RenderInitialMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("Snack Machine PipBoy Terminal");
            System.Console.WriteLine("----------------");
            System.Console.WriteLine("Choose an option:");

            foreach (var menuOption in menuOptions)
            {
                System.Console.WriteLine(menuOption.Value);
            }
            System.Console.WriteLine("----------------");
            RenderMachineDetails();
            System.Console.WriteLine("----------------");

            System.Console.Write("\r\nSelect an option: ");
        }
        
        private static Dictionary<char, string> menuOptions = 
            new()
            {
                ['1'] = "1 - Put 1 cent", 
                ['2'] = "2 - Put 10 cents",
                ['3'] = "3 - Put 25 cents",
                ['4'] = "4 - Put 1 Dollar",
                ['5'] = "5 - Put 5 Dollars",
                ['6'] = "6 - Put 20 Dollars",

                ['R'] = "R - Return Money",
                ['B'] = "B - Buy Snack",
                ['Q'] = "Q - Quit",
            };
    }
}
