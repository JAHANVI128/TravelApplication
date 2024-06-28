namespace Travela.Models.Entities
{
    public class PackageRequest
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageOverview { get; set; }
        public string Image { get; set; }
        public string AvlDates { get; set; }
        public int PackageAmt { get; set; }
        public int NoOfDays { get; set; }
        public int NoOfNights { get; set; }
        public string PackageType { get; set; }
        public string Itinerary { get; set; }
        public string Gallery { get; set; }
        public string Include { get; set; }
        public string Exclud { get; set; }
        public int SourceId { get; set; }
        public int DestinationId { get; set; }
        public int HotelId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}