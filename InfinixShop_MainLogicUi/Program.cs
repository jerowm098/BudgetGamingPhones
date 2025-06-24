using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using InfinixShop_BusinessLogic;
using InfinixShop_Common;

namespace InfinixShop
{
    internal class Program
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
            Console.WriteLine("\n------------------- \nINFINIX SHOP MENU");
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
            Console.WriteLine("\n------------------- \nChoose from the options below:");
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
            Console.WriteLine("\n------------------- \nPick your Choice:");
            for (int i = 0; i < phones.Length; i++)
            {
                Console.WriteLine(phones[i]);
            }

            int userChoice = GetUserInput();
            if (userChoice == phones.Length)
            {
                DisplayPhoneCategories();
                return;
            }

            if (userChoice >= 1 && userChoice < phones.Length)
            {
                string selectedPhone = phones[userChoice - 1].Substring(4);
                PhoneItem addedItem = InfinixShopLogic.AddToCart(selectedPhone);

                if (addedItem != null)
                {
                    Console.WriteLine($"\n------------------- \n{selectedPhone} added to cart!");
                }
                else
                {
                    Console.WriteLine("Item is already in the cart or failed to add!");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice! Try again.");
            }
            DisplayMainMenu();
        }

        static void RemoveItem()
        {
            Console.WriteLine("\n------------------- \nREMOVE ITEM:");

            List<string> cartItems = InfinixShopLogic.GetCartItemNames();
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
            if (userChoice == 0)
            {
                DisplayMainMenu();
                return;
            }

            if (userChoice > 0 && userChoice <= cartItems.Count)
            {
                string itemToRemove = cartItems[userChoice - 1];
                PhoneItem removedItem = InfinixShopLogic.RemoveFromCart(itemToRemove);
                if (removedItem != null)
                {
                    Console.WriteLine($"\n------------------- \n{itemToRemove} removed from cart!");
                }
                else
                {
                    Console.WriteLine("Failed to remove the item from the cart (item not found).");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice! Please select a valid item number or 0 to go back.");
            }

            DisplayMainMenu();
        }

        static void ViewCart()
        {
            Console.WriteLine("\n------------------- \nVIEW CART:");
            List<string> cartItems = InfinixShopLogic.GetCartItemNames();

            if (!cartItems.Any())
            {
                Console.WriteLine("Your cart is empty!");
            }
            else
            {
                Console.WriteLine("Items in your cart:");
                foreach (var item in cartItems)
                    Console.WriteLine($"- {item}");
            }

            Console.WriteLine("[0] Back");
            int userChoice = GetUserInput();
            if (userChoice == 0)
                DisplayMainMenu();
            else
            {
                Console.WriteLine("Invalid input. Press 0 to go back.");
                ViewCart();
            }
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