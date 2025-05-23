using System.Collections.Generic;
using System.Linq;
using InfinixShop_Common;

namespace InfinixShop_DataLogic
{
    public class InMemoryPhoneDataService : IPhoneDataService
    {
        private static List<PhoneItem> phoneCart = new List<PhoneItem>();
        private static int idCounter = 1;

        public bool AddItem(string name)
        {
            if (phoneCart.Any(p => p.Name == name)) return false;
            phoneCart.Add(new PhoneItem(idCounter++, name));
            return true;
        }

        public List<PhoneItem> GetAllItems()
        {
            return new List<PhoneItem>(phoneCart);
        }

        public bool UpdateItem(int id, string newName)
        {
            var item = phoneCart.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                item.Name = newName;
                return true;
            }
            return false;
        }

        public bool DeleteItem(int id)
        {
            var item = phoneCart.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                phoneCart.Remove(item);
                return true;
            }
            return false;
        }

        public PhoneItem SearchItemByName(string name)
        {
            return phoneCart.FirstOrDefault(p => p.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
