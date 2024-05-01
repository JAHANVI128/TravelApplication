using System.Collections.Generic;
using Travela.Model.System;
using Travela.Model.Service;

namespace Travela.IService.Service
{
    public interface ICityService
    {
        List<CityModel> GetAll();

        CityModel GetList(long id);

        JsonResponseModel AddOrUpdate(CityModel model);
        JsonResponseModel Delete(long EmpId);
    }
}
