using WaterUtilPro.Common;

namespace WaterUtilPro.Models
{
    public class Recipe : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Yield { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }

        

    }
}
