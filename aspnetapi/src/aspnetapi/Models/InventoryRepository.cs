using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetapi.Models
{
    public class InventoryRepository : IInventoryRepository
    {
        private static ConcurrentDictionary<string, InventoryItem> inventory =
              new ConcurrentDictionary<string, InventoryItem>();

        public InventoryRepository()
        {
            Add(new InventoryItem { Title = "Dell XPS 13 9050" });
        }

        public IEnumerable<InventoryItem> GetAll()
        {
            return inventory.Values;
        }

        public void Add(InventoryItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            inventory[item.Key] = item;
        }

        public InventoryItem Find(string key)
        {
            InventoryItem item;
            inventory.TryGetValue(key, out item);
            return item;
        }

        public InventoryItem Remove(string key)
        {
            InventoryItem item;
            inventory.TryRemove(key, out item);
            return item;
        }

        public void Update(InventoryItem item)
        {
            inventory[item.Key] = item;
        }
    }
}
