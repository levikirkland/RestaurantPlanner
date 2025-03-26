namespace WaterUtilPro.Models
{
    public class Vendor : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public string USPhone => String.Format("{0:(###) ###-####}", Convert.ToInt64(Phone));
        public string FullAddress => $"{Address} {City} {State} {PostalCode}";

    }
}
