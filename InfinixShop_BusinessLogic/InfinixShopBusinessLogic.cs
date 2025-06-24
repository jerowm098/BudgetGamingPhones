using System.Collections.Generic;
using System.Linq;
using InfinixShop_Common;
using InfinixShop_DataLogic;

namespace InfinixShop_BusinessLogic
{
    public static class InfinixShopLogic
    {
        // IMPORTANT: Configured to use SqlPhoneDataService for database persistence!
        //  private static IPhoneDataService dataService = new SqlPhoneDataService();

        // Uncomment one of these if you want to switch back to file/in-memory storage:

        // private static IPhoneDataService dataService = new InMemoryPhoneDataService();
        // private static IPhoneDataService dataService = new TextFilePhoneDataService();
        private static IPhoneDataService dataService = new JsonFilePhoneDataService();

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

        public static List<string> GetCartItemNames()
        {
            return dataService.GetAllItems().Select(p => p.Name).ToList();
        }

        public static List<PhoneItem> GetAllItemsInCart()
        {
            return dataService.GetAllItems();
        }

        public static PhoneItem SearchPhoneByName(string name)
        {
            return dataService.SearchItemByName(name);
        }
    }
}
