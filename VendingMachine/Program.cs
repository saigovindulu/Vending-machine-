using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static VendingMachine vendingMachine;
        static void Main(string[] args)
        {
            vendingMachine = VendingMachine.GetInstance();
            vendingMachine.AddObserver(new MachineLoggerObserver());
            vendingMachine.AddObserver(new MachineScreenObserver());

            PrintColored("- Initialized Vending Machine.", ConsoleColor.Cyan);
            RequestUserAction();
        }
        static void RequestUserAction()
        {
            Console.WriteLine("What action would you like to use?\n1 - Print Machine Info, 2 - Refill Machine, 3 - Purchase a Product\nHINT: Type EXIT to disconnect from the system.");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    PrintColored(vendingMachine.ToString(), ConsoleColor.Green);
                    break;
                
                case "2":
                    vendingMachine.RefillItems();
                    //
                    break;
                case "3":
                    ProductPurchase();
                    break;
                case "EXIT":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            RequestUserAction();
        }
        
        static void ProductPurchase()
        {
            Item requestedItem = null;
            string userInputString = string.Empty;
            int userInputInt;
            double userInputDouble;

            if (vendingMachine.MachineItems.Count == 0)
            {
                PrintColored("[ERROR] This vending machine does not have any items in stock.", ConsoleColor.Red);
                return;
            }

            PrintColored("Select the item you would like to purchase (Item ID).", ConsoleColor.Cyan);
            Console.WriteLine("HINT: Type EXIT in order to return to the previous menu.");
            PrintColored("Available Machine Items:", ConsoleColor.Cyan);
            foreach (Item item in vendingMachine.MachineItems.Keys)
            {
                PrintColored(string.Format("{0} [IN STOCK: {1}]", item.ToString(), vendingMachine.MachineItems[item]),
                    ConsoleColor.DarkGreen);
            }

            userInputString = Console.ReadLine();

            if (userInputString == "EXIT")
                return;

            if (!int.TryParse(userInputString, out userInputInt))
            {
                PrintColored("[ERROR] Invalid input.", ConsoleColor.Red);
                ProductPurchase();
                return;
            }

            foreach (Item item in vendingMachine.MachineItems.Keys)
            {
                if (item.ItemID == userInputInt)
                {
                    requestedItem = item;
                    break;
                }
            }

            if (requestedItem == null)
            {
                PrintColored("[ERROR] No such item in the vending machine. Please try again.", ConsoleColor.Red);
                ProductPurchase();
                return;
            }

            if (vendingMachine.GetItemStock(requestedItem) == 0)
            {
                PrintColored("[ERROR] Item is out of stock.", ConsoleColor.Red);
                ProductPurchase();
                return;
            }

            Console.WriteLine(requestedItem);
            Console.WriteLine("How much money are you paying?");
            userInputString = Console.ReadLine();

            if (!Double.TryParse(userInputString, out userInputDouble))
            {
                PrintColored("[ERROR] Invalid input.", ConsoleColor.Red);
                ProductPurchase();
                return;
            }
            if (userInputDouble < requestedItem.ItemPrice)
            {
                PrintColored("[ERROR]  Item price is higher than the paid amount.", ConsoleColor.Red);
                ProductPurchase();
                return;
            }

            vendingMachine.SellItem(requestedItem, userInputDouble);

            string recordMessage = string.Format("[Vending Machine]: Item has been successfully sold (Paid: {0}, Returned: {1}).",
                    userInputDouble.ToString("C"), (userInputDouble - requestedItem.ItemPrice).ToString("C"));

            PrintColored(recordMessage, ConsoleColor.Green);
        }
        static void PrintColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
