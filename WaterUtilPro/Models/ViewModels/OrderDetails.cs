using System.ComponentModel.DataAnnotations;

namespace WaterUtilPro.Models.ViewModels
{
    public class OrderDetails : Base
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }

        [Display(Name = "Inventory Name ")]
        public string InventoryName { get; set; }
        public int VendorId { get; set; }

        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }
        public int Quantity { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Cancel Date")]
        public DateTime? CancelDate { get; set; }

    }
}
