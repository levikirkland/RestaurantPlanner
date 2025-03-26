using WaterUtilPro.Common;

namespace WaterUtilPro.Models
{
    public class Ingredients : Base
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int InventoryId { get; set; }
        public Int16 UnitOfMeasureId { get; set; }
        public int Quantity { get; set; }

        

    }
}
//is issue with recipeid and inventoryid?