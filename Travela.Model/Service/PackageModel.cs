using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travela.Model.Service
{
    public class PackageModel
    {
        public int packageId { get; set; }
        public string packageName { get; set; }
        public string packageOverview { get; set; }
        public string image { get; set; }
        public string avlDates { get; set; }
        public int packageAmt { get; set; }
        public int noOfDays { get; set; }
        public int noOfNights { get; set; }
        public string packageType { get; set; }
        public string itinerary { get; set; }
        public string gallery { get; set; }
        public string include { get; set; }
        public string exclud { get; set; }
        public int sourceId { get; set; }
        public int destinationId { get; set; }
        public int hotelId { get; set; }
        public bool isActive { get; set; } = true;
        public bool isDelete { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
    }
}
