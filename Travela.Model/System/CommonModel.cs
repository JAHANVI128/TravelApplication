using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travela.Model.System
{
    public class JsonResponseModel
    {
        public bool isError { get; set; }
        public string strMessage { get; set; } = "";
        public string type { get; set; } = PopupMessageType.error.ToString();
        public dynamic? result { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
