namespace THosCase.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    
    using THosCase.Business.Abstraction;
    using THosCase.Business.Intefaces;
    using THosCase.Business.RequestModel;
    using THosCase.Business.ViewModel;

    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _userService.GetAll();

            var vmCategory = new UserViewModel
            {
                Users = users.Data,
                PageTitle = "Kullanıcılar"
            };

            return View(vmCategory);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var userServResult = _userService.GetAll();

            var vmCategory = new UserViewModel
            {
                Users = userServResult.Data,
                PageTitle = "Kullanıcılar"
            };

            return PartialView("_AddUserPartial");
        }


        [HttpPost]
        public ActionResult Add(UserRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceResult result = _userService.Add(requestModel);

                    if (!result.Succeeded)
                        TempData["SuccessMessage"] = result.Error.Message;

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Response.StatusCode = 400;
                    return Json(new
                    {
                        success = false,
                        errors = new List<string> { ex.Message },
                        message = "Kayıt sırasında hata oluştu: "
                    });
                }
            }

            return View(requestModel);
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult Update(UserRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceResult result = _userService.Update(requestModel);

                    if (!result.Succeeded)
                        TempData["SuccessMessage"] = result.Error.Message;

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Response.StatusCode = 400;
                    return Json(new
                    {
                        success = false,
                        errors = new List<string> { ex.Message },
                        message = "Güncelleme sırasında hata oluştu: "
                    });
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
                    ServiceResult result = _userService.Delete(id);

                    if (!result.Succeeded)
                        TempData["SuccessMessage"] = result.Error.Message;

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Silme sırasında hata oluştu: " + ex.Message);
                }
            }

            return View();
        }
    }
}