namespace Travela.Models.Entities
{
    public class DestinationRequest
    {
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
