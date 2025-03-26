using WaterUtilPro.Common;

namespace WaterUtilPro.Models
{
    public class RecipeInstructions : Base
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Int16 Step { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }

        

    }
}
