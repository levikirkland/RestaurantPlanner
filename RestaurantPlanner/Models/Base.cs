using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestaurantPlanner.Models
{
    public class Base
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Column("CreatedBy")]
        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }
        [Column("ModifiedBy")]
        [Display(Name = "Modified By")]
        public string? ModifiedBy { get; set; }
    }
}
