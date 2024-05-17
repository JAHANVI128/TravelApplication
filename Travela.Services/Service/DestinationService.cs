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
    public class DestinationService : IDestinationService
    {

        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public DestinationService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        #region Public Method(s)        

        public List<DestinationModel> GetAll()
        {
            _ = new List<DestinationModel>();
            List<DestinationModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<DestinationModel>("PROC_GetDestination", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into PROC_GetDestination", ex.ToString(), "DestinationService", "GetAll");
                lst = null;
            }
            return lst;
        }

        public DestinationModel GetById(long id)
        {
            try
            {
                var dataModel = GetAll().Where(x => x.destinationId == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into Get Destination Id", ex.ToString(), "DestinationService", "GetById");
                return null;
            }
        }

        public JsonResponseModel AddOrUpdate(DestinationModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("Id", model.destinationId);
                dictionary.Add("DestinationName", model.destinationName);
                dictionary.Add("IsActive", model.isActive);

                var data = dapperConnection.GetListResult<long>("InsertOrUpdateDestination", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.destinationId == 0)
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
                response.Message = "Destination added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating Destination.", ex.ToString(), "DestinationService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating destination.";
            }
            return response;
        }

        public JsonResponseModel Delete(long DestinationId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("Id", DestinationId);

                dapperConnection.GetListResult<int>("RemoveDestination", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "Destination deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting Destination with ID {DestinationId}.", ex.ToString(), "DestinationService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting source.";
            }
            return response;
        }

        #endregion

        #region Disposing Method(s)

        private bool disposed;

        ~DestinationService()
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