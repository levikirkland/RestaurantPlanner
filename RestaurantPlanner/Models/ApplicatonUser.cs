using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantPlanner.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
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
    }
}
