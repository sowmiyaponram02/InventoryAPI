using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models
{
    public class StockInventory
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int perUnitPrice { get; set; }

    }
}
