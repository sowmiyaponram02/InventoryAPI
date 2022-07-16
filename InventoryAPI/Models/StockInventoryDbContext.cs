using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Models
{
    public class StockInventoryDbContext : DbContext
    {
        public StockInventoryDbContext(DbContextOptions<StockInventoryDbContext> options) : base(options)
        {

        }

        public DbSet<StockInventory> InventoryItems { get; set; }
    }
}
