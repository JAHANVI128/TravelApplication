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
    public class SourceService : ISourceService
    {

        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public SourceService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        #region Public Method(s)        

        public List<SourceModel> GetAll()
        {
            _ = new List<SourceModel>();
            List<SourceModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<SourceModel>("PROC_GetSource", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into PROC_GetSource", ex.ToString(), "SourceService", "GetAll");
                lst = null;
            }
            return lst;
        }

        public SourceModel GetById(long id)
        {
            try
            {
                var dataModel = GetAll().Where(x => x.sourceId == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into Get Source Id", ex.ToString(), "SourceService", "GetById");
                return null;
            }
        }

        public JsonResponseModel AddOrUpdate(SourceModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("Id", model.sourceId);
                dictionary.Add("SourceName", model.sourceName);
                dictionary.Add("IsActive", model.isActive);

                var data = dapperConnection.GetListResult<long>("InsertOrUpdateSource", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.sourceId == 0)
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
                response.Message = "Source added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating source.", ex.ToString(), "SourceService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating source.";
            }
            return response;
        }

        public JsonResponseModel Delete(long SourceId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("Id", SourceId);

                dapperConnection.GetListResult<int>("RemoveSource", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "Source deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting Source with ID {SourceId}.", ex.ToString(), "SourceService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting source.";
            }
            return response;
        }


        #endregion

        #region Disposing Method(s)

        private bool disposed;

        ~SourceService()
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
            }
            disposed = true;
        }
        #endregion
    }
}
