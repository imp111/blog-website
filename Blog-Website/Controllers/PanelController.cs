using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Website.Controllers
{
    [Authorize(Roles = "Admin")]
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
