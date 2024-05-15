using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.Model.Service;
using Travela.Model.System;

namespace Travela.IService.Service
{
    public interface ISourceService
    {
        List<SourceModel> GetAll();

        SourceModel GetById(long id);

        JsonResponseModel AddOrUpdate(SourceModel model);
        JsonResponseModel Delete(long id);
    }
}
