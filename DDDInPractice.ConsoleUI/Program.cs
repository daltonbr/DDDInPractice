using DDDInPractice.Logic;
using static DDDInPractice.Logic.Money;

namespace DDDInPractice.ConsoleUI
{
    public class Program
    {
        private static readonly MainViewModel ViewModel = new();

        public static void Main(string[] args)
        {
            while(true)
            {
                RenderInitialMenu();

                ReadAndProcessOptions(Console.ReadKey().KeyChar);
            }
        }

        private static void ReadAndProcessOptions(char input)
        {
            char inputUpper = Convert.ToChar(input.ToString().ToUpper());
            switch (inputUpper)
            {
                case '1':
                    Console.WriteLine(" Put 1 cent");
                    InsertMoney(OneCent);
                    break;
                case '2':
                    Console.WriteLine(" Put 10 cent");
                    InsertMoney(TenCent);
                    break;
                case '3':
                    Console.WriteLine(" Put 25 cent");
                    InsertMoney(Quarter);
                    break;
                case '4':
                    Console.WriteLine(" Put 1 Dollar");
                    InsertMoney(OneDollar);
                    break;
                case '5':
                    Console.WriteLine(" Put 5 Dollars");
                    InsertMoney(FiveDollar);
                    break;
                case '6':
                    Console.WriteLine(" Put 20 Dollars");
                    InsertMoney(TwentyDollar);
                    break;
                case 'R':
                    Console.WriteLine(" Return Money");
                    ReturnMoney();
                    break;
                case 'B':
                    Console.WriteLine(" Buy Snack");
                    BuySnack();
                    break;
                case 'Q':
                    Console.WriteLine(" Quit");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"Invalid Option - {input}");
                    break;
            }
        }

        private static void InsertMoney(Money money) => ViewModel.InsertMoney(money);

        private static void ReturnMoney() => ViewModel.ReturnMoney();

        private static void BuySnack() => ViewModel.BuySnack();

        private static void RenderMachineDetails()
        {
            Console.WriteLine("----------------");
            Console.WriteLine($"Credits in current Transaction: {ViewModel.GetInTransactionText()}");
            Console.WriteLine($"Money Inside: {ViewModel.GetMoneyInsideText}");
            Console.WriteLine("----------------");
        }

        private static void RenderInitialMenu()
        {
            Console.Clear();
            Console.WriteLine("Snack Machine PipBoy Terminal");
            Console.WriteLine("----------------");
            Console.WriteLine("Choose an option:");

            foreach (var menuOption in MenuOptions)
            {
                Console.WriteLine(menuOption);
            }

            RenderMachineDetails();

            Console.Write("\r\nSelect an option: ");
        }
        
        private static readonly List<string> MenuOptions = 
            new()
            {
                "1 - Put 1 cent", 
                "2 - Put 10 cents",
                "3 - Put 25 cents",
                "4 - Put 1 Dollar",
                "5 - Put 5 Dollars",
                "6 - Put 20 Dollars",
                "R - Return Money",
                "B - Buy Snack",
                "Q - Quit",
            };
    }
}
