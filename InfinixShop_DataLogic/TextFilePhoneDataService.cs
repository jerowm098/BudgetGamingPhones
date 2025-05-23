using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InfinixShop_Common;

namespace InfinixShop_DataLogic
{
    public class TextFilePhoneDataService : IPhoneDataService
    {
        private readonly string filePath = "PhoneCart.txt";

        public bool AddItem(string name)
        {
            var items = GetAllItems();
            if (items.Any(p => p.Name == name)) return false;

            int newId = items.Any() ? items.Max(p => p.Id) + 1 : 1;
            items.Add(new PhoneItem(newId, name));
            SaveAllItems(items);
            return true;
        }

        public List<PhoneItem> GetAllItems()
        {
            var items = new List<PhoneItem>();

            if (!File.Exists(filePath))
                return items;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 2 && int.TryParse(parts[0], out int id))
                {
                    items.Add(new PhoneItem(id, parts[1]));
                }
            }

            return items;
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
            var lines = items.Select(p => $"{p.Id}|{p.Name}");
            File.WriteAllLines(filePath, lines);
        }
    }
}
