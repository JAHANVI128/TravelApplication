using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.Model.Service;
using Travela.Model.System;

namespace Travela.IService.Service
{
    public interface IDestinationService
    {
        List<DestinationModel> GetAll();

        DestinationModel GetById(long id);

        JsonResponseModel AddOrUpdate(DestinationModel model);
        JsonResponseModel Delete(long id);
    }
}
