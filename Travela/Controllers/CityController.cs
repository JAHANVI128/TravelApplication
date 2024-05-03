using Microsoft.AspNetCore.Mvc;
using Travela.Common;
using Travela.IService.Service;
using Travela.Model.Service;
using Travela.Model.System;
using Travela.Models.Entities;

namespace Travela.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        public IActionResult CityMaster()
        {
            //var cities = cityService.GetList();
            return View();
        }

        [HttpPost]
        [Route("/City/GetCityData")]
        public JsonResult GetCityData()
        {
            try
            {
                var lsdata =cityService.GetAll();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);

                return Json("");
            }

        }

        [HttpGet]
        public IActionResult EditCity(int cityId)
        {
            var city = cityService.GetList(cityId);
            if (city != null)
            {
                CityRequest cityRequest = new CityRequest();
                cityRequest.CityId = city.cityId;
                cityRequest.CityName = city.cityName;
                cityRequest.IsActive = city.isActive;
                cityRequest.IsDelete = city.isDelete;
                cityRequest.CreatedBy = city.createdBy;
                cityRequest.CreatedDate = city.createdDate;
                return View("CreateCity", cityRequest);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("/City/AddOrUpdateCity")]
        public JsonResponseModel AddOrUpdateCity(CityRequest cityRequest)
        {
            JsonResponseModel obj = new JsonResponseModel();

            try
            {
                CityModel model = new CityModel();
                //model.cityId = cityRequest.CityId;
                model.cityName = cityRequest.CityName;
                model.isActive = cityRequest.IsActive;
                //model.isDelete = cityRequest.IsDelete;
                //model.createdBy = cityRequest.CreatedBy;
                //model.createdDate = cityRequest.CreatedDate;

                var result = cityService.AddOrUpdate(model);

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
        public JsonResponseModel DeleteCity(int cityId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                objreturn = cityService.Delete(cityId);
            }
            catch (Exception ex)
            {
                return objreturn;
            }
            return objreturn;
        }   
    }
}