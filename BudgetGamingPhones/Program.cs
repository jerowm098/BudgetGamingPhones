using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using InfinixShop_BusinessLogic;

namespace InfinixShop
{
    class Program
    {
        static string[] mainMenuOptions = { "[1] Add Item", "[2] Remove Item", "[3] View Cart", "[4] Exit" };
        static string[] phoneCategories = { "[1] Entry Level Phones", "[2] Mid-range Phones", "[3] High-end Phones", "[4] Back" };
        static string[] entryLevelPhones = { "[1] Infinix Hot 50i 8GB RAM", "[2] Infinix Smart 9 8GB RAM", "[3] Infinix Note 40s 8GB RAM", "[4] Back" };
        static string[] midRangePhones = { "[1] Infinix Note 40 5G 20GB RAM", "[2] Infinix GT 20 Pro 5G 20GB RAM", "[3] Back" };
        static string[] highEndPhones = { "[1] Infinix Zero Flip 32GB RAM", "[2] Back" };

        static void Main(string[] args)
        {
            Console.WriteLine("Wanna take a look at our Latest Products?");
            Console.WriteLine("[1] View Shop\n[2] No Thanks");

            int userChoice = GetUserInput();
            if (userChoice == 1)
                DisplayMainMenu();
            else
                Console.WriteLine("Thank you for visiting! Have a great day!");
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("------------------- \nINFINIX SHOP MENU");
            foreach (var option in mainMenuOptions)
                Console.WriteLine(option);

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
                case 4:
                    Console.WriteLine("Thank you for visiting! Have a great day!");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    DisplayMainMenu();
                    break;
            }
        }

        static void DisplayPhoneCategories()
        {
            Console.WriteLine("------------------- \nChoose from the options below:");
            foreach (var category in phoneCategories)
                Console.WriteLine(category);

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
                case 4:
                    DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    DisplayPhoneCategories();
                    break;
            }
        }

        static void DisplayPhones(string[] phones)
        {
            Console.WriteLine("------------------- \nPick your Choice:");
            foreach (var phone in phones)
                Console.WriteLine(phone);

            int userChoice = GetUserInput();
            if (userChoice >= 1 && userChoice < phones.Length)
            {
                string selectedPhone = phones[userChoice - 1].Substring(4);
                if (InfinixShopLogic.AddToCart(selectedPhone))
                {
                    Console.WriteLine($"------------------- \n{selectedPhone} added to cart!");
                }
                else
                {
                    Console.WriteLine("Item is already in the cart!");
                }
            }
            DisplayMainMenu();
        }

        static void RemoveItem()
        {
            Console.WriteLine("------------------- \nREMOVE ITEM:");

            List<string> cartItems = InfinixShopLogic.GetCartItems();
            if (!cartItems.Any())
            {
                Console.WriteLine("Your cart is empty!");
                DisplayMainMenu();
                return;
            }

            for (int i = 0; i < cartItems.Count; i++)
                Console.WriteLine($"[{i + 1}] {cartItems[i]}");

            Console.WriteLine("[0] Back");

            int userChoice = GetUserInput();
            if (userChoice > 0 && userChoice <= cartItems.Count)
            {
                Console.WriteLine($"------------------- \n{cartItems[userChoice - 1]} removed from cart!");
                cartItems.RemoveAt(userChoice - 1);
            }

            DisplayMainMenu();
        }

        static void ViewCart()
        {
            Console.WriteLine("------------------- \nVIEW CART:");
            List<string> cartItems = InfinixShopLogic.GetCartItems();

            if (!cartItems.Any())
            {
                Console.WriteLine("Your cart is empty!");
            }
            else
            {
                foreach (var item in cartItems)
                    Console.WriteLine(item);
            }

            Console.WriteLine("[0] Back");
            if (GetUserInput() == 0)
                DisplayMainMenu();
        }

        static int GetUserInput()
        {
            Console.Write("[User Input]: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int userInput))
            {
                Thread.Sleep(700);
                return userInput;
            }
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return GetUserInput();
        }
    }
}
