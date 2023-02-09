using Microsoft.AspNetCore.Mvc;

namespace Blog_Website.Controllers
{
    public class PanelController : Controller
    {
        public PanelController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
