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
                Dictionary<string, object> dictionary = new Dictionary<string, object>
                {
                    { "Id", model.hotelId },
                    { "HotelImg", model.hotelImage },
                    { "HotelName", model.hotelName },
                    { "HotelPhone", model.hotelPhone },
                    { "CityId", model.cityId },
                    { "RoomTypeId", model.roomType },
                    { "IsActive", model.isActive }
                };

                var data = dapperConnection.GetListResult<long>("InsertOrUpdateHotel", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (data > 0 && model.roomList != null)
                {
                    foreach (var room in model.roomList)
                    {
                        var roomDictionary = new Dictionary<string, object>
                        {
                            { "p_HotelId", data },
                            { "p_RoomTypeId", room.roomTypeId },
                            { "p_RoomNo", room.roomNo },
                            { "p_Amount", room.amount },
                            { "p_IsActive", room.isActive }
                        };
                        dapperConnection.ExecuteWithoutResult("InsertOrUpdateHotelRooms", CommandType.StoredProcedure, roomDictionary);
                    }
                }

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

        public JsonResponseModel Delete(long hotelId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                var parameters = new Dictionary<string, object> { { "Id", hotelId } };

                dapperConnection.ExecuteWithoutResult("RemoveHotel", CommandType.StoredProcedure, parameters);
                //dapperConnection.ExecuteWithoutResult("RemoveRooms", CommandType.StoredProcedure, parameters);

                response.Success = true;
                response.isError = false;
                response.Message = "Hotel deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting hotel with ID {hotelId}.", ex.ToString(), "HotelService", "Delete");
                response.Success = false;
                response.isError = true;
                response.Message = "An error occurred while deleting the hotel.";
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