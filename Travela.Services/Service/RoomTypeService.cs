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
    public class RoomTypeService : IRoomTypeService
    {

        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public RoomTypeService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        #region Public Method(s)        

        public List<RoomTypeModel> GetAll()
        {
            _ = new List<RoomTypeModel>();
            List<RoomTypeModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<RoomTypeModel>("PROC_GetRoomType", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into PROC_GetRoomType", ex.ToString(), "RoomTypeService", "GetAll");
                lst = null;
            }
            return lst;
        }

        public RoomTypeModel GetById(long id)
        {
            try
            {
                var dataModel = GetAll().Where(x => x.roomTypeId == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into Get RoomType Id", ex.ToString(), "RoomTypeService", "GetById");
                return null;
            }
        }

        public JsonResponseModel AddOrUpdate(RoomTypeModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("Id", model.roomTypeId);
                dictionary.Add("RoomTypeName", model.roomTypeName);
                dictionary.Add("IsActive", model.isActive);

                var data = dapperConnection.GetListResult<long>("InsertOrUpdateRoomType", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.roomTypeId == 0)
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
                response.Message = "RoomType added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating RoomType.", ex.ToString(), "RoomTypeService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating RoomType.";
            }
            return response;
        }

        public JsonResponseModel Delete(long RoomTypeId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("Id", RoomTypeId);

                dapperConnection.GetListResult<int>("RemoveRoomType", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "RoomType deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting Room Type with ID {RoomTypeId}.", ex.ToString(), "RoomTypeService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting RoomType.";
            }
            return response;
        }

        #endregion

        #region Disposing Method(s)

        private bool disposed;

        ~RoomTypeService()
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
