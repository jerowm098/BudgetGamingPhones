using System.Collections.Generic;
using System.Linq;
using InfinixShop_Common;
using InfinixShop_DataLogic;

namespace InfinixShop_BusinessLogic
{
    public static class InfinixShopLogic
    {
        // Swap this with TextFilePhoneDataService or JsonFilePhoneDataService to change storage
        private static IPhoneDataService dataService = new InMemoryPhoneDataService();
        // private static IPhoneDataService dataService = new TextFilePhoneDataService();
        // private static IPhoneDataService dataService = new JsonFilePhoneDataService();

        public static bool AddToCart(string phoneName)
        {
            return dataService.AddItem(phoneName);
        }

        public static bool RemoveFromCart(string phoneName)
        {
            var item = dataService.SearchItemByName(phoneName);
            if (item != null)
                return dataService.DeleteItem(item.Id);
            return false;
        }

        public static List<string> GetCartItems()
        {
            return dataService.GetAllItems().Select(p => p.Name).ToList();
        }
    }
}
