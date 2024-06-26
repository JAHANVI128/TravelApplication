using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.Model.Service;
using Travela.Model.System;

namespace Travela.IService.Service
{
    public interface IPackageService
    {
        List<PackageModel> GetAll();

        PackageModel GetById(long id);

        JsonResponseModel AddOrUpdate(PackageModel model);
        JsonResponseModel Delete(long id);
    }
}
