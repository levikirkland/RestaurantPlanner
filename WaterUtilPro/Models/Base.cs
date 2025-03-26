using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterUtilPro.Models
{
    public class Base
    {
        [Column("CreatedDate")]
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Column("ModifiedDate")]
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Column("CreatedBy")]
        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [Column("ModifiedBy")]
        [Display(Name = "Modified By")]
        public string? ModifiedBy { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
