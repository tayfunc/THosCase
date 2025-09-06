namespace THosCase.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    
    using THosCase.Business;
    using THosCase.Business.Abstraction;
    using THosCase.Business.Intefaces;
    using THosCase.Business.RequestModel;
    using THosCase.Business.ViewModel;

    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var categories = _categoryService.GetAll();

            var vmCategory = new CategoryViewModel
            {
                Categories = categories.Data,
                PageTitle = "Kategoriler"
            };

            ViewBag.ParentCategories = categories.Data;

            return View(vmCategory);
        }

        [HttpGet]
        public ActionResult Add()
        {
            // Parent kategorileri dropdown için hazırla
            var catServResult = _categoryService.GetAll();

            var vmCategory = new CategoryViewModel
            {
                Categories = catServResult.Data,
                PageTitle = "Kategoriler"
            };

            ViewBag.ParentCategories = catServResult.Data.Where(x=> x.ParentCategoryId == 0).ToList();
            ViewBag.Users = new List<UserModel>();

            return PartialView("_AddCategoryPartial");
        }

        [HttpPost]
        public ActionResult Add(CategoryRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceResult result = _categoryService.Add(requestModel);

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
        public ActionResult Update(CategoryRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceResult result = _categoryService.Update(requestModel);

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
                    ServiceResult result = _categoryService.Delete(id);

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