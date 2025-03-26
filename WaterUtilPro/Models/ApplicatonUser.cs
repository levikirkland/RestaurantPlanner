using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterUtilPro.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int AccountInfoId { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Column("CreatedBy")]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Column("ModifiedBy")]
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
