namespace THosCase.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    using THosCase.Business.Abstraction;
    using THosCase.Business.Intefaces;
    using THosCase.Business.RequestModel;
    using THosCase.Business.ViewModel;

    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        private readonly IPropertyService _propertyService;

        private readonly IProductPropertyService _productPropertyService;

        public ProductController(IProductService productService, ICategoryService categoryService, IPropertyService propertyService, IProductPropertyService productPropertyService)
        {
            _productService = productService;

            _categoryService = categoryService;

            _propertyService = propertyService;

            _productPropertyService = productPropertyService;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _productService.GetAll();

            var categories = _categoryService.GetAll();

            var properties = _propertyService.GetAll();

            var vmProduct = new ProductViewModel
            {
                Products = products.Data,
                Categories = categories.Data,
                Properties = properties.Data,
                PageTitle = "Ürünler"
            };

            ViewBag.Categories = categories.Data;

            ViewBag.Properties = properties.Data;

            return View(vmProduct);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var productServResult = _productService.GetAll();

            var categories = _categoryService.GetAll();

            var properties = _propertyService.GetAll();

            var vmCategory = new ProductViewModel
            {
                Products = productServResult.Data,
                Categories= categories.Data,
                Properties = properties.Data,
                PageTitle = "Ürünler"
            };

            ViewBag.Categories = categories.Data;
            
            ViewBag.Properties = properties.Data;

            return PartialView("_AddProductPartial");
        }

        [HttpGet]
        public ActionResult AddProductProperty()
        {
            var productServResult = _productService.GetAll();

            var properties = _propertyService.GetAll();

            var vmCategory = new ProductViewModel
            {
                Products = productServResult.Data,
                Properties = properties.Data,
                PageTitle = "Özellikler"
            };

            ViewBag.Properties = properties.Data;

            return PartialView("_AddProductPropertyPartial");
        }

        [HttpPost]
        public ActionResult Add(ProductRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Resim yükleme işlemi
                    if (requestModel.ImageFile != null && requestModel.ImageFile.ContentLength > 0)
                    {
                        requestModel.ImagePath = SaveImage(requestModel.ImageFile);
                    }

                    ServiceResult result = _productService.Add(requestModel);

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
        public ActionResult AddProperty(ProductPropertyRequestModel requestModel)
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
        public ActionResult Update(ProductRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Yeni resim yüklendiyse
                    if (requestModel.ImageFile != null && requestModel.ImageFile.ContentLength > 0)
                    {
                        // Eski resmi sil (opsiyonel)
                        if (!string.IsNullOrEmpty(requestModel.ImagePath))
                        {
                            DeleteImage(requestModel.ImagePath);
                        }

                        // Yeni resmi kaydet
                        requestModel.ImagePath = SaveImage(requestModel.ImageFile);
                    }

                    ServiceResult result = _productService.Update(requestModel);

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
                    ServiceResult result = _productService.Delete(id);

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

        /// <summary>
        /// Save Image
        /// </summary>
        private string SaveImage(HttpPostedFileBase imageFile)
        {
            // Dosya validasyonu
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            string[] allowedMimeTypes = { "image/jpeg", "image/png", "image/gif", "image/bmp" };

            string fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
            string mimeType = imageFile.ContentType.ToLower();

            if (!allowedExtensions.Contains(fileExtension) || !allowedMimeTypes.Contains(mimeType))
            {
                throw new Exception("Geçersiz dosya formatı. Sadece resim dosyaları yükleyebilirsiniz.");
            }

            // Dosya boyutu kontrolü (max 5MB)
            if (imageFile.ContentLength > 5 * 1024 * 1024)
            {
                throw new Exception("Dosya boyutu 5MB'tan büyük olamaz.");
            }

            // Klasör yolunu belirle
            string uploadsFolder = Server.MapPath("~/Uploads/Images/");

            // Klasör yoksa oluştur
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Benzersiz dosya adı oluştur
            string fileName = $"{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString().Substring(0, 8)}{fileExtension}";
            string filePath = Path.Combine(uploadsFolder, fileName);

            // Dosyayı kaydet
            imageFile.SaveAs(filePath);

            // Veritabanında sadece dosya adını sakla veya relative path
            return fileName; // veya return $"~/Uploads/Images/{fileName}";
        }

        /// <summary>
        /// Delete Image
        /// </summary>
        private void DeleteImage(string imagePath)
        {
            try
            {
                // Sadece dosya adı saklanıyorsa
                string fileName = Path.GetFileName(imagePath);
                string filePath = Path.Combine(Server.MapPath("~/Uploads/Images/"), fileName);

                // Full path saklanıyorsa
                // string filePath = Server.MapPath(imagePath);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                // Loglama yapabilirsiniz
                System.Diagnostics.Debug.WriteLine("Resim silinirken hata: " + ex.Message);
            }
        }
    }
}