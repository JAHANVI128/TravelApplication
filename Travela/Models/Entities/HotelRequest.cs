namespace Travela.Models.Entities
{
    public class HotelRequest
    {
        public int HotelId { get; set; }
        public IFormFile HotelImage { get; set; }
        public string HotelName { get; set; }
        public int HotelPhone { get; set; }
        public int CityId { get; set; }
        public string strcity { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<HotelRoomRequest> RoomList { get; set; } = new List<HotelRoomRequest>();
    }


    public class HotelRoomRequest
    {
        public int  RoomTypeId { get; set; }
        public int RoomNo { get; set; }
        public string Amount { get; set; }
    }

    //public class HotelRoom
    //{
    //    public int HotelRoomId { get; set; }
    //    public int HotelId { get; set; }
    //    public int RoomTypeId { get; set; }
    //    public int RoomNo { get; set; }
    //    public decimal Amount { get; set; }
    //    public bool IsActive { get; set; }
    //    public bool IsDelete { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //}
}
