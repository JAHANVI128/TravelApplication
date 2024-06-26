using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.Model.Service;
using Travela.Model.System;

namespace Travela.IService.Service
{
    public interface IHotelService
    {
        List<HotelModel> GetAll();

        HotelModel GetById(long id);

        JsonResponseModel AddOrUpdate(HotelModel model);
        JsonResponseModel Delete(long id);
    }
}