namespace THosCase.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web.Mvc;
    using System.Xml.Linq;

    using THosCase.Data.Interfaces; // Interface klasörü
    using THosCase.Models;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        // Constructor injection
        public HomeController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public ActionResult Index()
        {
            var categories = _categoryRepository.GetAll();
            var products = _productRepository.GetAll();

            var model = categories.Select(c => new CategoryProductCountViewModel
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                ProductCount = products.Count(p => p.CategoryId == c.CategoryId && !p.IsDeleted)
            }).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult GetCurrencies()
        {
            Response.ContentType = "text/html; charset=utf-8";
            Response.Charset = "utf-8";

            var url = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var client = new WebClient();
            string xmlContent = client.DownloadString(url);

            var xdoc = XDocument.Parse(xmlContent);
            var codes = new[] { "USD", "EUR", "AUD", "DKK", "CAD", "SAR", "JPY", "BGN", "RUB" };
            var result = xdoc.Descendants("Currency")
                .Where(x => codes.Contains((string)x.Attribute("CurrencyCode")))
                .Select(x => new
                {
                    Code = (string)x.Attribute("CurrencyCode"),
                    Name = AutoDetectAndConvert((string)x.Element("Isim")),
                    ForexBuying = (string)x.Element("ForexBuying"),
                    ForexSelling = (string)x.Element("ForexSelling")
                }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private static string AutoDetectAndConvert(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            // Türkçe karakter bozukluk pattern'leri
            var commonPatterns = new Dictionary<string, string>
            {
                {"Ã§", "ç"}, {"Ã‡", "Ç"},
                {"ÄŸ", "ğ"}, {"Ä", "Ğ"},
                {"Ã¶", "ö"}, {"Ã–", "Ö"},
                {"ÅŸ", "ş"}, {"�z", "Ş"},
                {"Ã¼", "ü"}, {"Ãœ", "Ü"},
                {"Ã½", "ı"}, {"Ä°", "İ"}
            };

            foreach (var pattern in commonPatterns)
            {
                if (text.Contains(pattern.Key))
                {
                    // ISO-8859-9 encoding deneyelim
                    byte[] bytes = Encoding.GetEncoding("ISO-8859-9").GetBytes(text);
                    return Encoding.UTF8.GetString(bytes);
                }
            }

            return text; // Değişiklik yapma
        }
    }
}