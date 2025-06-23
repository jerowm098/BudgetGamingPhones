using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using InfinixShop_Common;

namespace InfinixShop_DataLogic
{
    public class JsonFilePhoneDataService : IPhoneDataService
    {
        private readonly string filePath = "PhoneCart.json";

        public bool AddItem(string name)
        {
            var items = GetAllItems();
            if (items.Any(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase))) return false;

            int newId = items.Any() ? items.Max(p => p.Id) + 1 : 1;
            items.Add(new PhoneItem(newId, name));
            SaveAllItems(items);
            return true;
        }

        public List<PhoneItem> GetAllItems()
        {
            if (!File.Exists(filePath)) return new List<PhoneItem>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<PhoneItem>>(json) ?? new List<PhoneItem>();
        }

        public bool UpdateItem(int id, string newName)
        {
            var items = GetAllItems();
            var item = items.FirstOrDefault(p => p.Id == id);
            if (item == null) return false;

            item.Name = newName;
            SaveAllItems(items);
            return true;
        }

        public bool DeleteItem(int id)
        {
            var items = GetAllItems();
            var item = items.FirstOrDefault(p => p.Id == id);
            if (item == null) return false;

            items.Remove(item);
            SaveAllItems(items);
            return true;
        }

        public PhoneItem SearchItemByName(string name)
        {
            return GetAllItems().FirstOrDefault(p => p.Name.ToLower().Contains(name.ToLower()));
        }

        private void SaveAllItems(List<PhoneItem> items)
        {
            string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
