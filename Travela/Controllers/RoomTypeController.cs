using Microsoft.AspNetCore.Mvc;
using Travela.Common;
using Travela.IService.Service;
using Travela.Model.Service;
using Travela.Model.System;
using Travela.Models.Entities;
using Travela.Services.Service;

namespace Travela.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeService roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            this.roomTypeService = roomTypeService;
        }

        [HttpGet]
        public IActionResult RoomTypeMaster()
        {
            return View();
        }

        [HttpGet]
        [Route("/RoomType/RoomTypeList")]
        public IActionResult RoomTypeList()
        {
            var rooms = roomTypeService.GetAll();
            return Json(rooms);
        }

        [HttpPost]
        [Route("/RoomType/GetRoomTypeData")]
        public JsonResult GetRoomTypeData()
        {
            try
            {
                var lsdata = roomTypeService.GetAll();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
                return Json("");
            }
        }

        [HttpGet]
        [Route("/RoomType/EditRoomType")]
        public JsonResponseModel EditRoomType(int roomTypeId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var roomType = roomTypeService.GetById(roomTypeId);
                if (roomType != null)
                {
                    objreturn.result = roomType;
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
        [Route("/RoomType/AddOrUpdateRoomType")]
        public JsonResponseModel AddOrUpdateRoomType(RoomTypeRequest roomTypeRequest)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                RoomTypeModel model = new RoomTypeModel();
                model.roomTypeId = roomTypeRequest.RoomTypeId;
                model.roomTypeName = roomTypeRequest.RoomTypeName;
                model.isActive = roomTypeRequest.IsActive;

                var result = roomTypeService.AddOrUpdate(model);

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

        [HttpGet]
        [Route("/RoomType/GetRoomTypes")]
        public JsonResponseModel GetRoomTypes()
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var roomTypes = roomTypeService.GetAll();
                objreturn.result = roomTypes;
                objreturn.isError = false;
            }
            catch (Exception ex)
            {
                objreturn.isError = true;
                objreturn.Message = "An error occurred: " + ex.Message;
            }
            return objreturn;
        }

        [HttpPost]
        [Route("/RoomType/DeleteRoomType")]
        public JsonResponseModel DeleteRoomType(int roomTypeId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                objreturn = roomTypeService.Delete(roomTypeId);
            }
            catch (Exception ex)
            {
                return objreturn;
            }
            return objreturn;
        }
    }
}
