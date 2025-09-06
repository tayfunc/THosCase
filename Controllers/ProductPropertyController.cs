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
    public class ProductPropertyController : Controller
    {
        private readonly IProductService _productService;

        private readonly IProductPropertyService _productPropertyService;

        public ProductPropertyController(IProductPropertyService productPropertyService, IProductService productService)
        {
            _productPropertyService = productPropertyService;

            _productService = productService;
        }

        public ActionResult Index()
        {
            var products = _productService.GetAll();

            var productProperties = _productPropertyService.GetAll();

            var vmProductProperty = new ProductPropertyViewModel
            {
                Products = products.Data,
                PageTitle = "Ürün Özellikleri"
            };

            ViewBag.Products = products.Data;

            return View(vmProductProperty);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var products = _productService.GetAll();

            var productProperties = _productPropertyService.GetAll();

            var vmCategory = new ProductPropertyViewModel
            {
                Products = products.Data,
                PageTitle = "Ürün Özellikleri"
            };

            ViewBag.Products = products.Data;

            return PartialView("_AddProductPropertyPartial");
        }

        [HttpPost]
        public ActionResult Add(ProductPropertyRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceResult result = _productPropertyService.Add(requestModel);

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
        public ActionResult Update(ProductPropertyRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceResult result = _productPropertyService.Update(requestModel);

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
                    ServiceResult result = _productPropertyService.Delete(id);

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