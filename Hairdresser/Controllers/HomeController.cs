using System.Diagnostics;
using System.Net.Http.Headers;
using Hairdresser.Context;
using Hairdresser.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hairdresser.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;


        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ApplicationDbContext context, IWebHostEnvironment environment, ILogger<HomeController> logger)
        {
            _context = context;
            _environment = environment;
            _logger = logger;
        }

        public IActionResult YapayZekaOneri()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> YapayZekaOneri(IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                ViewBag.Error = "Lütfen bir fotoðraf yükleyin.";
                return View();
            }

            // Fotoðrafý kaydet
            var filePath = Path.Combine(_environment.WebRootPath, "uploads", photo.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            // OpenAI API'ye istek yap
            var result = await CallOpenAIAPI(filePath);
            ViewBag.Response = result;

            return View();
        }

        private async Task<string> CallOpenAIAPI(string filePath)
        {
            var apiUrl = "https://api.openai.com/v1/images/generations"; // DALL·E endpointi
            var apiKey = "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"; // OpenAI API Key

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            // OpenAI API'ye JSON isteði hazýrla
            var requestData = new
            {
                prompt = "Generate a high-quality image of a modern,  haircut for the woman in the photo, keeping the face intact.",
                n = 1, // Tek bir görsel üret
                size = "1024x1024"
            };

            var json = System.Text.Json.JsonSerializer.Serialize(requestData);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(apiUrl, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"OpenAI API Hatasý: {responseContent}");
            }

            return responseContent;
        }




        public IActionResult Index()
        {
            var salon = _context.salons.FirstOrDefault();  //salons tablosundaki ilk kaydý alýr
            return View(salon);
        }

        public IActionResult Hizmetler()
        {
            return View();
        }

        public IActionResult BizKimiz()
        {
            return View();
        }

        public IActionResult Ýletisim()
        {
            return View();
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
