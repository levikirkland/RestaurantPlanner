using System.ComponentModel.DataAnnotations;

namespace WaterUtilPro.Models.ViewModels
{
    public class InventoryDetails
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Unit of Measure")]
        public string UnitOfMeasure { get; set; }

        public string Category { get; set; }
        public string? Location { get; set; }

        [Display(Name = "Quantity In Stock")]
        public int QtyInStock { get; set; }

        [Display(Name = "Order Quantity")]
        public int OrderQuantity { get; set; }

        [Display(Name = "Reorder Quantity")]
        public int ReorderQty { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Unit Cost")]
        public decimal UnitCost { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Restock Date")]
        public DateTime? ReStockDate { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

    }
}
