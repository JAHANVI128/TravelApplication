using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travela.Model.Service
{
    public class HotelModel
    {
        public int hotelId { get; set; }
        public string hotelImage { get; set; }
        public string hotelName { get; set; }
        public int hotelPhone { get; set; }
        public int cityId { get; set; }
        public string strcity { get; set; }
        public bool isActive { get; set; } = true;
        public bool isDelete { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
    }
}
