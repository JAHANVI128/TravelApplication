using Microsoft.AspNetCore.Mvc;
using Travela.Common;
using Travela.IService.Service;
using Travela.Model.Service;
using Travela.Model.System;
using Travela.Models.Entities;
using Travela.Services.Service;

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
            return View();
        }

        [HttpGet]
        [Route("/City/CityList")]
        public IActionResult CityList()
        {
            var city = cityService.GetAll();
            return Json(city);
        }

        [HttpPost]
        [Route("/City/GetCityData")]
        public JsonResult GetCityData()
        {
            try
            {
                var lsdata = cityService.GetAll();
                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
                return Json("");
            }
        }

        [HttpGet]
        [Route("/City/EditCity")]
        public JsonResponseModel EditCity(int cityId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var city = cityService.GetById(cityId);
                if (city != null)
                {
                    objreturn.result = city;
                    return objreturn;
                }
                else
                {
                    return objreturn;
                }
            }
            catch(Exception ex)
            {
                objreturn.isError = true;
                return objreturn;
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
                model.cityId = cityRequest.CityId;
                model.cityName = cityRequest.CityName;
                model.isActive = cityRequest.IsActive;

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
        [Route("/City/DeleteCity")]
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