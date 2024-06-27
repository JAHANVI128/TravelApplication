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
    public class PackageService : IPackageService
    {

        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public PackageService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        #region Public Method(s)        

        public List<PackageModel> GetAll()
        {
            _ = new List<PackageModel>();
            List<PackageModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<PackageModel>("PROC_GetPackage", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into PROC_GetAllPackage", ex.ToString(), "PackageService", "GetAll");
                lst = null;
            }
            return lst;
        }

        public PackageModel GetById(long id)
        {
            try
            {
                var dataModel = GetAll().Where(x => x.packageId == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into GetAll package id", ex.ToString(), "PackageService", "GetList");
                return null;
            }
        }

        public JsonResponseModel AddOrUpdate(PackageModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("Id", model.packageId);
                dictionary.Add("PackageName", model.packageName);
                dictionary.Add("IsActive", model.isActive);

                var data = dapperConnection.GetListResult<long>("InsertOrUpdatePackage", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.packageId == 0)
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
                response.Message = "Package added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating package.", ex.ToString(), "PackageService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating package.";
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

                dapperConnection.GetListResult<int>("RemoveCity", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "Package deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting package with ID /*{PackageId}*/.", ex.ToString(), "CityService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting source.";
            }
            return response;
        }
        #endregion

        #region Disposing Method(s)

        private bool disposed;

        ~PackageService()
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
