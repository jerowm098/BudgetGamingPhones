using System.Collections.Generic;
using System.Linq;
using InfinixShop_Common;

namespace InfinixShop_DataLogic
{
    public class InMemoryPhoneDataService : IPhoneDataService
    {
        private static List<PhoneItem> _phoneItems = new List<PhoneItem>();
        private static int _nextId = 1;

        public bool AddItem(string name)
        {
            if (_phoneItems.Any(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            _phoneItems.Add(new PhoneItem(_nextId++, name));
            return true;
        }

        public List<PhoneItem> GetAllItems()
        {
            return new List<PhoneItem>(_phoneItems);
        }

        public bool UpdateItem(int id, string newName)
        {
            var item = _phoneItems.FirstOrDefault(p => p.Id == id);
            if (item == null) return false;

            item.Name = newName;
            return true;
        }

        public bool DeleteItem(int id)
        {
            var item = _phoneItems.FirstOrDefault(p => p.Id == id);
            if (item == null) return false;

            _phoneItems.Remove(item);
            return true;
        }

        public PhoneItem SearchItemByName(string name)
        {
            return _phoneItems.FirstOrDefault(p => p.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
