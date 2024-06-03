namespace Travela.Models.Entities
{
    public class HotelRequest
    {
        public int HotelId { get; set; }
        public IFormFile HotelImage { get; set; }
        public string HotelName { get; set; }
        public string HotelPhone { get; set; }
        public string CityId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
