using System.ComponentModel.DataAnnotations;

namespace WaterUtilPro.Models.ViewModels
{
    public class IngredientsViewModel
    {

        public string Name { get; set; }

        [Display(Name = "Unit of Measure")]
        public string UnitOfMeasure { get; set; }
        public int Quantity { get; set; }

    }
}
