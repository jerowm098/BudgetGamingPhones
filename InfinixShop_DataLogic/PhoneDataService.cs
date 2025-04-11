using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InfinixShop_Common;

namespace InfinixShop_DataLogic
{
    public class PhoneDataService
    {
        private static List<PhoneItem> phoneCart = new List<PhoneItem>();
        private static int idCounter = 1;

        public bool AddItem(string name) // Create (Add a phone item to the cart)
        {
            if (phoneCart.Any(p => p.Name == name))
                return false;

            phoneCart.Add(new PhoneItem(idCounter++, name));
            return true;
        }

        public List<PhoneItem> GetAllItems() // Read/View (Get all phone items in the cart)
        {
            return new List<PhoneItem>(phoneCart);
        }

        public bool UpdateItem(int id, string newName) // Update (Update a phone item based on its ID)
        {
            var item = phoneCart.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                item.Name = newName;
                return true;
            }
            return false;
        }

        public bool DeleteItem(int id) // Delete (Remove a phone item based on its ID)
        {
            var item = phoneCart.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                phoneCart.Remove(item);
                return true;
            }
            return false;
        }

        public PhoneItem SearchItemByName(string name) // Search (Search for a phone item by name)
        {
            return phoneCart.FirstOrDefault(p => p.Name.ToLower().Contains(name.ToLower()));
        }
    }
}