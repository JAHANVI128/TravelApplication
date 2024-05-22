using Microsoft.AspNetCore.Mvc;
using Travela.Common;
using Travela.IService.Service;
using Travela.Model.Service;
using Travela.Model.System;
using Travela.Models.Entities;
using Travela.Services.Service;

namespace Travela.Controllers
{
    public class SourceController : Controller
    {
        private readonly ISourceService sourceService;

        public SourceController(ISourceService sourceService)
        {
            this.sourceService = sourceService;
        }

        [HttpGet]
        public IActionResult SourceMaster()
        {
            return View();
        }

        [HttpPost]
        [Route("/Source/GetSourceData")]
        public JsonResult GetSourceData()
        {
            try
            {
                var lsdata = sourceService.GetAll();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
                return Json("");
            }
        }

        [HttpGet]
        [Route("/Source/EditSource")]
        public JsonResponseModel EditSource(int sourceId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var source = sourceService.GetById(sourceId);
                if (source != null)
                {
                    objreturn.result = source;
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
        [Route("/Source/AddOrUpdateSource")]
        public JsonResponseModel AddOrUpdateSource(SourceRequest sourceRequest)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                SourceModel model = new SourceModel();
                model.sourceId = sourceRequest.SourceId;
                model.sourceName = sourceRequest.SourceName;
                model.isActive = sourceRequest.IsActive;

                var result = sourceService.AddOrUpdate(model);

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
        [Route("/Source/DeleteSource")]
        public JsonResponseModel DeleteSource(int sourceId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                objreturn = sourceService.Delete(sourceId);
            }
            catch (Exception ex)
            {
                return objreturn;
            }
            return objreturn;
        }
    }
}