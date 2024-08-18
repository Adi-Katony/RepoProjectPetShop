using Microsoft.AspNetCore.Mvc;

namespace ProjectPetShop.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "There was an unexpected error. Please come back later";
            return View();
        }
    }
}
