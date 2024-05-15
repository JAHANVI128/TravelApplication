using Microsoft.AspNetCore.Mvc;
using Travela.Common;
using Travela.IService.Service;
using Travela.Model.Service;
using Travela.Model.System;
using Travela.Models.Entities;

namespace Travela.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            this.destinationService = destinationService;
        }

        [HttpGet]
        public IActionResult DestinationMaster()
        {
            return View();
        }

        [HttpPost]
        [Route("/Destination/GetDestinationData")]
        public JsonResult GetDestinationData()
        {
            try
            {
                var lsdata = destinationService.GetAll();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
                return Json("");
            }
        }

        [HttpGet]
        [Route("/Destination/EditDestination")]
        public JsonResponseModel EditDestination(int destinationId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var destination = destinationService.GetById(destinationId);
                if (destination != null)
                {
                    objreturn.result = destination;
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
        [Route("/Destination/AddOrUpdateDestination")]
        public JsonResponseModel AddOrUpdateDestination(DestinationRequest destinationRequest)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                DestinationModel model = new DestinationModel();
                model.destinationId = destinationRequest.DestinationId;
                model.destinationName = destinationRequest.DestinationName;
                model.isActive = destinationRequest.IsActive;

                var result = destinationService.AddOrUpdate(model);

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
        [Route("/Destination/DeleteDestination")]
        public JsonResponseModel DeleteDestination(int destinationId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                objreturn = destinationService.Delete(destinationId);
            }
            catch (Exception ex)
            {
                return objreturn;
            }
            return objreturn;
        }
    }
}
