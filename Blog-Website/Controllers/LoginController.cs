using Microsoft.AspNetCore.Mvc;

namespace Blog_Website.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
