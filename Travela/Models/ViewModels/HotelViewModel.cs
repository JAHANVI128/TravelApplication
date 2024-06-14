using Travela.Models.Entities;

namespace Travela.Models.ViewModels
{
    public class HotelViewModel
    {
        public HotelRequest Hotel { get; set; } = new HotelRequest();
        public List<HotelRoomRequest> HotelRooms { get; set; } = new List<HotelRoomRequest>();
        public List<RoomTypeRequest> RoomTypes { get; set; } = new List<RoomTypeRequest>();
    }
}
