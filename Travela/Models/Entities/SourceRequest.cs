namespace Travela.Models.Entities
{
    public class SourceRequest
    {
        public int SourceId { get; set; }
        public string SourceName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
