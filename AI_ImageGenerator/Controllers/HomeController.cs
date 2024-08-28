using AI_ImageGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//using System.Web.Mvc;
//using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ImageGenerator _imageGenerator;

        public HomeController()
        {
            _imageGenerator = new ImageGenerator();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GenerateImage(string prompt)
        {
            var result = await _imageGenerator.GenerateImageAsync(prompt);
            ViewBag.Result = result;
            return View("Index");
        }
    }
}



