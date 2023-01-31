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
            IEnumerable<Post> postsList = _db.Posts;
            return View(postsList); // returns a view with all the posts
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
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int? id) // POST HTTP METHOD
        {
            _db.Posts.Find(id);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET-Delete Expense, works with the view
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Posts.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-Delete Expense, works with the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteExpense(int? id)
        {
            var obj = _db.Posts.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Posts.Remove(obj);
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