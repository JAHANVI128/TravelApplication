namespace Travela.Models.Entities
{
    public class RoomTypeRequest
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
