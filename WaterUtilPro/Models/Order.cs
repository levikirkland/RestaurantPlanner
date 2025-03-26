namespace WaterUtilPro.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int VendorId { get; set; }
        public int Quantity { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
