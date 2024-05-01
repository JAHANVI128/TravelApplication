using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travela.Model.Service
{
   public class CityModel
    {
        public int cityId { get; set; }
        public string cityName { get; set; }
        public bool isActive { get; set; } = true;
        public bool isDelete { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
    }
}
