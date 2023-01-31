using Blog_Website.Data;
using Blog_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Post() // GET HTTP METHOD
        {
            return View(new Post());
        }

        [HttpPost]
        public IActionResult Post(Post post) // POST HTTP METHOD
        {
            _db.Posts.Add(post);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit() // GET HTTP METHOD
        {
            return View(new Post());
        }

        [HttpPost]
        public IActionResult Edit(Post post) // POST HTTP METHOD
        {
            _db.Posts.Add(post);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}