using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinixShop_BusinessLogic
{
    public class InfinixShopLogic
    {
        private static List<string> cart = new List<string>();

        // Method to add an item to the cart
        public static bool AddToCart(string item)
        {
            if (string.IsNullOrEmpty(item) || cart.Contains(item))
                return false;

            cart.Add(item);
            return true;
        }
        // Method to remove an item from the cart
        public static bool RemoveFromCart(int index)
        {
            if (index >= 0 && index < cart.Count)
            {
                cart.RemoveAt(index);
                return true;
            }
            return false;
        }
        // Method to get all cart items
        public static List<string> GetCartItems()
        {
            return new List<string>(cart); // Return a copy of the cart to prevent external modification
        }
    }
}
