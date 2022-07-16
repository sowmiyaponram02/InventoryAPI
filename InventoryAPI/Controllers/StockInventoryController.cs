using InventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockInventoryController : ControllerBase
    {
        private readonly StockInventoryDbContext context;
        public StockInventoryController(StockInventoryDbContext _context)
        {
            context = _context;
        }
        // GET: api/<StockInventoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockInventory>>>  GetAllInventoryItems()
        {
            return await context.InventoryItems.ToListAsync();
        }

        // GET api/<StockInventoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockInventory>> Get(int id)
        {
            var val =await context.InventoryItems.FirstOrDefaultAsync(x=>x.Id == id);
            if (val != null)
                return val;
            return NotFound();
        }

        // POST api/<StockInventoryController>
        [HttpPost]
        public async Task<ActionResult<StockInventory>> Post([FromBody] StockInventory value)
        {
            context.InventoryItems.Add(value);
            await context.SaveChangesAsync();
            return CreatedAtAction("Get",new { id = value.Id },value);
        }

        // PUT api/<StockInventoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StockInventory value)
        {
            var res = await context.InventoryItems.FindAsync(id);
            if(res != null)
            {
                res.Id = value.Id;
                res.Name = value.Name;
                res.Code = value.Code;
                res.Quantity = value.Quantity;
                res.perUnitPrice = value.perUnitPrice;
                context.InventoryItems.Update(res);
                await context.SaveChangesAsync();
                return Ok();

            }
            return NotFound();
        }

        // DELETE api/<StockInventoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await context.InventoryItems.FindAsync(id);
            if (res == null) {
                return NotFound();
            }
            context.InventoryItems.Remove(res);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
