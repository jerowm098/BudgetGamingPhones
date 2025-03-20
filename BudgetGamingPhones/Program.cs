using System; // Import the System namespace to use basic functionalities
using System.Collections.Generic; // Import collections to use List
using System.Threading; // Import threading to add delay

namespace InfinixShop
{
    internal class Program
    {
        // List to store items added to the shopping cart
        static List<string> cart = new List<string>();

        // Menu options for the main menu and submenus
        static string[] mainMenuOptions = new string[] { "[1] Add Item", "[2] Remove Item", "[3] View Cart", "[4] Exit" };
        static string[] phoneCategories = new string[] { "[1] Entry Level Phones", "[2] Mid-range Phones", "[3] High-end Phones", "[4] Back" };
        static string[] entryLevelPhones = new string[] { "[1] Infinix Hot 50i 8GB RAM", "[2] Infinix Smart 9 8GB RAM", "[3] Infinix Note 40s 8GB RAM", "[4] Back" };
        static string[] midRangePhones = new string[] { "[1] Infinix Note 40 5G 20GB RAM", "[2] Infinix GT 20 Pro 5G 20GB RAM", "[3] Back" };
        static string[] highEndPhones = new string[] { "[1] Infinix Zero Flip 32GB RAM", "[2] Back" };

        static void Main(string[] args)
        {
            // Initial prompt to ask the user if they want to view the shop
            Console.WriteLine("Wanna take a look at our Latest Products?");
            Console.WriteLine("[1] View Shop\n[2] No Thanks");

            int userChoice = GetUserInput();

            switch (userChoice)
            {
                case 1:
                    DisplayMainMenu();
                    break;
                case 2:
                    Console.WriteLine("Thank you for visiting! Have a great day!");
                    break;
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("------------------- \nINFINIX SHOP MENU");
            foreach (var option in mainMenuOptions)
            {
                Console.WriteLine(option);
            }

            int userChoice = GetUserInput();
            switch (userChoice)
            {
                case 1:
                    DisplayPhoneCategories();
                    break;
                case 2:
                    RemoveItem();
                    break;
                case 3:
                    ViewCart();
                    break;
                default:
                    Console.WriteLine("Thank you for visiting! Have a great day!");
                    break;
            }
        }

        static void DisplayPhoneCategories()
        {
            Console.WriteLine("------------------- \nChoose from the options below:");
            foreach (var category in phoneCategories)
            {
                Console.WriteLine(category);
            }

            int userChoice = GetUserInput();
            switch (userChoice)
            {
                case 1:
                    DisplayPhones(entryLevelPhones);
                    break;
                case 2:
                    DisplayPhones(midRangePhones);
                    break;
                case 3:
                    DisplayPhones(highEndPhones);
                    break;
                default:
                    DisplayMainMenu();
                    break;
            }
        }

        static void DisplayPhones(string[] phones)
        {
            Console.WriteLine("------------------- \nPick your Choice:");
            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
            }

            int userChoice = GetUserInput();
            if (userChoice >= 1 && userChoice < phones.Length)
            {
                cart.Add(phones[userChoice - 1].Substring(4)); // Add phone to cart
                Console.WriteLine($"------------------- \n{phones[userChoice - 1].Substring(4)} added to cart!");
            }
            DisplayMainMenu();
        }

        static void RemoveItem()
        {
            Console.WriteLine("------------------- \nREMOVE ITEM: ");
            if (cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty!");
            }
            else
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {cart[i]}");
                }
                Console.WriteLine("[0] Back");

                int userChoice = GetUserInput();
                if (userChoice > 0 && userChoice <= cart.Count)
                {
                    Console.WriteLine($"------------------- \n{cart[userChoice - 1]} removed from cart!");
                    cart.RemoveAt(userChoice - 1);
                }
            }
            DisplayMainMenu();
        }

        static void ViewCart()
        {
            Console.WriteLine("------------------- \nVIEW CART:");
            if (cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty!");
            }
            else
            {
                foreach (var item in cart)
                {
                    Console.WriteLine(item);
                }
            }
            DisplayMainMenu();
        }

        static int GetUserInput()
        {
            Console.Write("[User Input]:  ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int userInput))
            {
                Thread.Sleep(500);
                return userInput;
            }
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return GetUserInput(); // Recursively ask for correct input
        }
    }
}
