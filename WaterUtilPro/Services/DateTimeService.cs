using WaterUtilPro.Interfaces;

namespace WaterUtilPro.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
