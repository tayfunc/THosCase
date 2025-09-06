namespace THosCase.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using THosCase.Business.Abstraction;
    using THosCase.Business.Intefaces;
    using THosCase.Business.RequestModel;
    using THosCase.Business.ViewModel;

    /// <summary>
    /// Product Property Controller
    /// </summary>
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public ActionResult Index()
        {
            var properties = _propertyService.GetAll();

            var vmProperty = new PropertyViewModel
            {
                Properties = properties.Data,
                PageTitle = "Özellikler"
            };

            return View(vmProperty);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var properties = _propertyService.GetAll();

            var vmCategory = new PropertyViewModel
            {
                Properties = properties.Data,
                PageTitle = "Özellikler"
            };

            return PartialView("_AddPropertyPartial");
        }

        [HttpPost]
        public ActionResult Add(PropertyRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceResult result = _propertyService.Add(requestModel);

                    if (!result.Succeeded)
                        TempData["SuccessMessage"] = result.Error.Message;

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Kayıt sırasında hata oluştu: " + ex.Message);
                }
            }

            return View(requestModel);
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult Update(PropertyRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceResult result = _propertyService.Update(requestModel);

                    if (!result.Succeeded)
                        TempData["SuccessMessage"] = result.Error.Message;

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Güncelleme sırasında hata oluştu: " + ex.Message);
                }
            }

            return View(requestModel);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceResult result = _propertyService.Delete(id);

                    if (!result.Succeeded)
                    {
                        Response.StatusCode = 400;
                        return Json(new
                        {
                            success = false,
                            errors = new List<string> { result.Error.Message },
                            message = "Silme sırasında hata oluştu: "
                        });
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Güncelleme sırasında hata oluştu: " + ex.Message);
                }
            }

            return View();
        }
    }
}