using Microsoft.AspNetCore.Mvc;
using Travela.Common;
using Travela.IService.Service;
using Travela.Model.Service;
using Travela.Model.System;
using Travela.Models.Entities;
using System.IO;
using Travela.Services.Service;

namespace Travela.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService hotelService;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet]
        public IActionResult HotelMaster()
        {
            return View();
        }

        [HttpPost]
        [Route("/Hotel/GetHotelData")]
        public JsonResult GetHotelData()
        {
            try
            {
                var lsdata = hotelService.GetAll();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
                return Json(new { recordsFiltered = 0, recordsTotal = 0, data = new List<HotelModel>(), error = ex.Message });
            }
        }

        [HttpGet]
        [Route("/Hotel/EditHotel")]
        public JsonResponseModel EditHotel(int hotelId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var hotel = hotelService.GetById(hotelId);
                if (hotel != null)
                {
                    objreturn.result = hotel;
                    objreturn.Success = true;
                }
                else
                {
                    objreturn.Message = "Hotel not found.";
                    objreturn.Success = false;
                }
            }
            catch (Exception ex)
            {
                objreturn.isError = true;
                objreturn.Message = "An error occurred: " + ex.Message;
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
            }
            return objreturn;
        }

        [HttpPost]
        [Route("/Hotel/AddOrUpdateHotel")]
        public JsonResponseModel AddOrUpdateHotel(HotelRequest HotelRequest)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                HotelModel model = new HotelModel();

                // Check if an image file is uploaded
                if (HotelRequest.HotelImage != null && HotelRequest.HotelImage.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(HotelRequest.HotelImage.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        HotelRequest.HotelImage.CopyTo(stream);
                    }
                    model.hotelImage = "/Images/" + fileName;
                }

                model.hotelId = HotelRequest.HotelId;
                model.hotelName = HotelRequest.HotelName;
                model.hotelPhone = HotelRequest.HotelPhone;
                model.cityId = HotelRequest.CityId;
                model.isActive = HotelRequest.IsActive;
                model.roomList = HotelRequest.RoomList.Select(r => new HotelRoomModel
                {
                    hotelRoomId = r.HotelRoomId,
                    roomTypeId = r.RoomTypeId,
                    roomNo = r.RoomNo,
                    amount = r.Amount,
                    isActive = r.IsActive
                }).ToList();

                var result = hotelService.AddOrUpdate(model);

                obj.result = result.result;
                obj.Message = "Record saved successfully";
                obj.Success = result.Success;
            }
            catch (Exception ex)
            {
                obj.result = false;
                obj.Message = "An error occurred: " + ex.Message;
                obj.Success = false;
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
            }
            return obj;
        }

        [HttpPost]
        [Route("/Hotel/DeleteHotel")]
        public JsonResult DeleteHotel(long hotelId)
        {
            var result = hotelService.Delete(hotelId);
            return Json(result);
        }
    }
}