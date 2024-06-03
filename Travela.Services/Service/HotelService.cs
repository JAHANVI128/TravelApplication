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
    public class HotelService : IHotelService
    {

        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public HotelService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        #region Public Method(s)        

        public List<HotelModel> GetAll()
        {
            _ = new List<HotelModel>();
            List<HotelModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<HotelModel>("PROC_GetHotel", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into PROC_GetHotel", ex.ToString(), "HotelService", "GetAll");
                lst = null;
            }
            return lst;
        }

        public HotelModel GetById(long id)
        {
            try
            {
                var dataModel = GetAll().Where(x => x.hotelId == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into Get Hotel Id", ex.ToString(), "HotelService", "GetById");
                return null;
            }
        }

        public JsonResponseModel AddOrUpdate(HotelModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("Id", model.hotelId);
                dictionary.Add("HotelImage", model.hotelImage);
                dictionary.Add("HotelName", model.hotelName);
                dictionary.Add("HotelPhone", model.hotelPhone);
                dictionary.Add("CityId", model.cityId);
                dictionary.Add("IsActive", model.isActive);

                var data = dapperConnection.GetListResult<long>("InsertOrUpdateHotel", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.hotelId == 0)
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
                response.Message = "Hotel added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating hotel.", ex.ToString(), "HotelService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating hotel.";
            }
            return response;
        }

        public JsonResponseModel Delete(long HotelId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("Id", HotelId);

                dapperConnection.GetListResult<int>("RemoveHotel", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "Hotel deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting Source with ID {HotelId}.", ex.ToString(), "HotelService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting hotel.";
            }
            return response;
        }

        #endregion

        #region Disposing Method(s)

        private bool disposed;

        ~HotelService()
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