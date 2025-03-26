using WaterUtilPro.Common;
using System.ComponentModel.DataAnnotations;

namespace WaterUtilPro.Models
{
    public class Purchase : Base
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int VendorId { get; set; }
        public DateTime PurchaseDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }
        
    }
}
