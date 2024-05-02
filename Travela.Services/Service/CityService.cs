using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.Common;
using Travela.IService.Service;
using Travela.Model.Service;
using Travela.Model.System;

namespace Travela.Services.Service
{
   public class CityService : ICityService
    {

        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public CityService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        #region Public Method(s)        

        public List<CityModel> GetAll()
        {
            _ = new List<CityModel>();
            List<CityModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<CityModel>("PROC_GetCity", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into PROC_GetAllCity", ex.ToString(), "CityService", "GetAll");
                lst = null;
            }
            return lst;
        }

        public CityModel GetList(long id)
        {
            try
            {
                var dataModel = GetAll().Where(x => x.cityId == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into GetAll city id", ex.ToString(), "CityService", "GetList");
                return null;
            }
        }

        public JsonResponseModel AddOrUpdate(CityModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("Id", model.cityId);
                dictionary.Add("CityName", model.cityName);

                var data = dapperConnection.GetListResult<long>("InsertOrUpdateCity", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.cityId == 0)
                {
                    response.strMessage = "Register successfully";
                }
                else
                {
                    response.strMessage = "Record updated successfully";
                }
                response.isError = false;
                response.type = PopupMessageType.success.ToString();
                response.result = data;

                response.Success = true;
                response.Message = "City added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating city.", ex.ToString(), "CityService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating city.";
            }
            return response;

        }


        public JsonResponseModel Delete(long CityId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("Id", CityId);

                // Your logic for deleting employee here
                dapperConnection.GetListResult<int>("RemoveCity", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "City deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting city with ID {CityId}.", ex.ToString(), "CityService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting employee.";
            }
            return response;
        }


        #endregion
        
        #region Disposing Method(s)

        private bool disposed;

        ~CityService()
        {
            Dispose(false);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here.
                }

                // Dispose unmanaged resources here.
            }

            disposed = true;
        }


        #endregion
    }
}
