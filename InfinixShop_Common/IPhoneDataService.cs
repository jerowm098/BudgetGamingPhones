using System.Collections.Generic;

namespace InfinixShop_Common
{
    public interface IPhoneDataService
    {
        bool AddItem(string name);
        List<PhoneItem> GetAllItems();
        bool UpdateItem(int id, string newName);
        bool DeleteItem(int id);
        PhoneItem SearchItemByName(string name);
    }
}
