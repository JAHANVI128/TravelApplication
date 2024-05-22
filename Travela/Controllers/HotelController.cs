using Microsoft.AspNetCore.Mvc;
using Travela.Common;
using Travela.IService.Service;
using Travela.Model.Service;
using Travela.Model.System;
using Travela.Models.Entities;

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
                return Json("");
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
                    return objreturn;
                }
                else
                {
                    return objreturn;
                }
            }
            catch (Exception ex)
            {
                objreturn.isError = true;
                return objreturn;
            }
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
                model.hotelEmail = HotelRequest.HotelEmail;
                model.hotelAddress = HotelRequest.HotelAddress;
                model.hotelDescription = HotelRequest.HotelDescription;
                model.isActive = HotelRequest.IsActive;

                var result = hotelService.AddOrUpdate(model);

                obj.result = result.result;
                obj.Message = "Record saved successfully";
            }
            catch (Exception ex)
            {
                obj.result = false;
                obj.Message = "An error occurred: " + ex.Message;
            }
            return obj;
        }

        [HttpPost]
        [Route("/Hotel/DeleteHotel")]
        public JsonResponseModel DeleteHotel(int hotelId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                objreturn = hotelService.Delete(hotelId);
            }
            catch (Exception ex)
            {
                return objreturn;
            }
            return objreturn;
        }
    }
}