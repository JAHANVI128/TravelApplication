namespace Travela.Models.Entities
{
    public class CityRequest
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
