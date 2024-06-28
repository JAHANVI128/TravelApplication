using Microsoft.AspNetCore.Mvc;
using Travela.Common;
using Travela.IService.Service;
using Travela.Model.Service;
using Travela.Model.System;
using Travela.Models.Entities;
using Travela.Services.Service;

namespace Travela.Controllers
{
    public class PackageController : Controller
    {
        private readonly IPackageService packageService;

        public PackageController(IPackageService packageService)
        {
            this.packageService = packageService;
        }

        [HttpGet]
        public IActionResult PackageMaster()
        {
            return View();
        }

        [HttpGet]
        [Route("/Package/PackageList")]
        public IActionResult PackageList()
        {
            var package = packageService.GetAll();
            return Json(package);
        }

        [HttpPost]
        [Route("/Package/GetPackageData")]
        public JsonResult GetPackageData()
        {
            try
            {
                var lsdata = packageService.GetAll();
                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
                return Json("");
            }
        }

        [HttpGet]
        [Route("/Package/EditPackage")]
        public JsonResponseModel EditPackage(int packageId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var package = packageService.GetById(packageId);
                if (package != null)
                {
                    objreturn.result = package;
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
        [Route("/Package/AddOrUpdatePackage")]
        public JsonResponseModel AddOrUpdatePackage(PackageRequest packageRequest)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                PackageModel model = new PackageModel();
                model.packageId = packageRequest.PackageId;
                model.packageName = packageRequest.PackageName;
                model.avlDates = packageRequest.AvlDates;
                model.isActive = packageRequest.IsActive;

                var result = packageService.AddOrUpdate(model);

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
        [Route("/Package/DeletePackage")]
        public JsonResponseModel DeletePackage(int packageId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                objreturn = packageService.Delete(packageId);
            }
            catch (Exception ex)
            {
                return objreturn;
            }
            return objreturn;
        }
    }
}