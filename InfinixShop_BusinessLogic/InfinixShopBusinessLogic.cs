using System.Collections.Generic;
using System.Linq;
using InfinixShop_Common;
using InfinixShop_DataLogic;

namespace InfinixShop_BusinessLogic
{
    public static class InfinixShopLogic
    {
        // private static IPhoneDataService dataService = new SqlPhoneDataService();
        // private static IPhoneDataService dataService = new InMemoryPhoneDataService();
        // private static IPhoneDataService dataService = new TextFilePhoneDataService();
        private static IPhoneDataService dataService = new JsonFilePhoneDataService();

        public static PhoneItem AddToCart(string phoneName)
        {
            var existingItem = dataService.SearchItemByName(phoneName);
            if (existingItem != null)
            {
                return null;
            }
            bool addedSuccessfully = dataService.AddItem(phoneName);
            if (addedSuccessfully)
            {
                return dataService.SearchItemByName(phoneName);
            }
            return null;
        }

        public static PhoneItem RemoveFromCart(string phoneName)
        {
            var itemToRemove = dataService.SearchItemByName(phoneName);
            if (itemToRemove != null)
            {
                bool deleted = dataService.DeleteItem(itemToRemove.Id);
                if (deleted)
                {
                    return itemToRemove;
                }
            }
            return null;
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

        public static PhoneItem UpdatePhoneName(int id, string newName)
        {
            bool updated = dataService.UpdateItem(id, newName);
            if (updated)
            {
                return dataService.SearchItemByName(newName);
            }
            return null;
        }
    }
}