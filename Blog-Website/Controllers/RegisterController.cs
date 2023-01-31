using Microsoft.AspNetCore.Mvc;

namespace Blog_Website.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
