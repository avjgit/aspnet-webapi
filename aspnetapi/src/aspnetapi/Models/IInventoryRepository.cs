using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetapi.Models
{
    public interface IInventoryRepository
    {
        void Add(InventoryItem item);
        IEnumerable<InventoryItem> GetAll();
        InventoryItem Find(string key);
        InventoryItem Remove(string key);
        void Update(InventoryItem item);
    }
}
