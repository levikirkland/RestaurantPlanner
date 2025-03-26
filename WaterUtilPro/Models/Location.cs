using WaterUtilPro.Common;
using WaterUtilPro.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WaterUtilPro.Models
{
    public class Location : Base
    {
        public int Id { get; set; }

        [Display(Name = "Location Name")]
        public int AccountInfoId { get; set; }
        public string LocationName { get; set; } = string.Empty;
        [Display(Name = "Contact First Name")]
        public string ContactFirstName { get; set; } = string.Empty;
        [Display(Name = "Contact Last Name")]
        public string ContactLastName { get; set; } = string.Empty;
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; } = string.Empty;
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;
        [Display(Name = "Address")]
        public string Address1 { get; set; } = string.Empty;
        [Display(Name = "Address 2")]
        public string? Address2 { get; set; }
        public string City { get; set; } = string.Empty;
        public States State { get; set; }
        public string Zipcode { get; set; } = string.Empty;
        [Display(Name = "Deactivation Date")]
        public DateTime? DeactivationDate { get; set; }
        public DateTime SignUpDate { get; set; }
        [NotMapped]
        public string USPhone => String.Format("{0:(###) ###-####}", $"{Phone}");
        [NotMapped]
        public string CanPhone => String.Format("{0:(###) ###-####}", $"{Phone}");
        [NotMapped]
        public string FullAddress => $"{Address1} {City} {State} {Zipcode}";


        

    }
}
