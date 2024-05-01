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
                ErrorLogger.Error("Error Into PROC_GetAllEmployee", ex.ToString(), "CityService", "GetAll");
                lst = null;
            }
            return lst;
        }

        public CityModel Get(long id)
        {
            try
            {
                var dataModel = GetAll().Where(x => x.cityId == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into GetAll employee id", ex.ToString(), "GalleryService", "Get");
                return null;
            }
        }

        public JsonResponseModel AddOrUpdate(CityModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("EmpId", model.cityId);
                dictionary.Add("IsActive", model.isActive);

                var data = dapperConnection.GetListResult<long>("InsertOrUpdateEmployee", CommandType.StoredProcedure, dictionary).FirstOrDefault();

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
                response.Message = "Employee added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating employee.", ex.ToString(), "EmployeeService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating employee.";
            }
            return response;

        }


        public JsonResponseModel Delete(long EmpId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("EmpId", EmpId);

                // Your logic for deleting employee here
                dapperConnection.GetListResult<int>("RemoveEmployee", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "Employee deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting employee with ID {EmpId}.", ex.ToString(), "EmployeeService", "Delete");
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
