using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.Model.Service;
using Travela.Model.System;

namespace Travela.IService.Service
{
    public interface IRoomTypeService
    {
        List<RoomTypeModel> GetAll();

        RoomTypeModel GetById(long id);

        JsonResponseModel AddOrUpdate(RoomTypeModel model);
        JsonResponseModel Delete(long id);
    }
}
