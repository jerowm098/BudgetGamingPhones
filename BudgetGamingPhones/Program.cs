using System;

namespace BudgetGamingPhones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Infinix Shop");
            Console.ReadKey();
            Console.WriteLine("Wanna take a look for our Latest Products?");
            Console.WriteLine("[1] View Shop?\n[2] No Thanks, Its Cheap!");

            int userChoice = Convert.ToInt16(Console.ReadLine());

            if (userChoice == 2)
            {
                Console.WriteLine("Thank you for visiting! Have a great day!");
                return;
            }

            while (true)
            {
                Console.WriteLine("Choose from the following options:");
                Console.WriteLine("[1] Entry Level Phones (Price range: 10,000)");
                Console.WriteLine("[2] Mid-range Phones (Price range: 20,000)");
                Console.WriteLine("[3] High-end Phones (Price range: 30,000)");
                Console.WriteLine("[4] Back");

                int phoneChoice = Convert.ToInt16(Console.ReadLine());

                if (phoneChoice == 4)
                {
                    Console.WriteLine("Returning to main menu...");
                    continue;
                }

                if (phoneChoice == 1)
                {
                    Console.WriteLine("Select an Entry Level phone:");
                    Console.WriteLine("[1] Infinix Hot 50i 8GB RAM");
                    Console.WriteLine("[2] Infinix Smart 9 8GB RAM");
                    Console.WriteLine("[3] Infinix Note 40s 8GB RAM");
                    Console.WriteLine("[4] Back");
                }
                else if (phoneChoice == 2)
                {
                    Console.WriteLine("Select a Mid-range phone:");
                    Console.WriteLine("[1] Infinix Note 40 5G 20GB RAM");
                    Console.WriteLine("[2] Infinix GT 20 Pro 5G 20GB RAM");
                    Console.WriteLine("[3] Back");
                }
                else if (phoneChoice == 3)
                {
                    Console.WriteLine("Select a High-end phone:");
                    Console.WriteLine("[1] Infinix Zero Flip 32GB RAM");
                    Console.WriteLine("[2] Back");
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                    continue;
                }

                int selectedPhone = Convert.ToInt16(Console.ReadLine());

                // Check if user wants to go back
                if (selectedPhone == 4 || selectedPhone == 3 && phoneChoice != 1)
                {
                    Console.WriteLine("Returning to phone selection...");
                    continue;
                }

                string phoneName = "";

                switch (phoneChoice)
                {
                    case 1: // Entry Level Phones
                        if (selectedPhone == 1) phoneName = "Infinix Hot 50i 8GB RAM";
                        else if (selectedPhone == 2) phoneName = "Infinix Smart 9 8GB RAM";
                        else if (selectedPhone == 3) phoneName = "Infinix Note 40s 8GB RAM";
                        break;
                    case 2: // Mid-range Phones
                        if (selectedPhone == 1) phoneName = "Infinix Note 40 5G 20GB RAM";
                        else if (selectedPhone == 2) phoneName = "Infinix GT 20 Pro 5G 20GB RAM";
                        break;
                    case 3: // High-end Phones
                        if (selectedPhone == 1) phoneName = "Infinix Zero Flip 32GB RAM";
                        break;
                }

                if (string.IsNullOrEmpty(phoneName))
                {
                    Console.WriteLine("Invalid selection, please try again.");
                    continue;
                }

                Console.WriteLine($"Check-in {phoneName}?");
                Console.WriteLine("[1] Yes\n[2] No");
                int checkInChoice = Convert.ToInt16(Console.ReadLine());

                if (checkInChoice == 1)
                {
                    Console.WriteLine($"Wow! You bought {phoneName}!");
                    Console.ReadKey();
                    Console.WriteLine("Thank you for shopping! Come Again!");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Returning to main menu...");
                }
            }
        }
    }
}
