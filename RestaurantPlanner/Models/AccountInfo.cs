using RestaurantPlanner.Common.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using RestaurantPlanner.Common;
using RestaurantPlanner.Events;

namespace RestaurantPlanner.Models
{
    public class AccountInfo : Base, IHasDomainEvent
    {
        public int Id { get; set; }
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; } = string.Empty;
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
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
        [Display(Name = "Account Type")]
        public AccountTypes AccountType { get; set; }
        [Display(Name = "Deactivation Date")]
        public DateTime? DeactivationDate { get; set; }
        public bool? IsActive { get; set; }
        private DateTime _signUpDate;

        public DateTime SignUpDate 
        { 
            get  => _signUpDate; 
            set
            { 
                if (value == DateTime.Today)
                {
                    DomainEvents.Add(new CreatedNewAccountEvent(this));
                }
            }
        }

        [NotMapped]
        public string USPhone => String.Format("{0:(###) ###-####}", $"{Phone}");
        [NotMapped]
        public string CanPhone => String.Format("{0:(###) ###-####}", $"{Phone}");
        [NotMapped]
        public string FullAddress => $"{Address1} {City} {State} {Zipcode}"; 
       

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

    }
}
