using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string CarDescription { get; set; }
    }
}
