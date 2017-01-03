using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnetapi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace aspnetapi.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        public InventoryController(IInventoryRepository inventory)
        {
            Inventory = inventory;
        }

        public IInventoryRepository Inventory { get; set; }

        // GET: api/values
        [HttpGet]
        public IEnumerable<InventoryItem> Get()
        {
            return Inventory.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetItem")]
        public IActionResult Get(string id)
        {
            var item = Inventory.Find(id);
            if (item == null) return NotFound();
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]InventoryItem item)
        {
            if (item == null) return BadRequest();
            Inventory.Add(item);
            return CreatedAtRoute("GetItem", new { id = item.Key }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]InventoryItem item)
        {
            if (item == null || item.Key != id) return BadRequest();
            var inventoryItem = Inventory.Find(id);
            if (inventoryItem == null) return NotFound();
            Inventory.Update(item);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var inventoryItem = Inventory.Find(id);
            if (inventoryItem == null) return NotFound();
            Inventory.Remove(id);
            return new NoContentResult();
        }
    }
}
