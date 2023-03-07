using Blog_Website.Data;
using Blog_Website.Data.Repository;
using Blog_Website.Migrations;
using Blog_Website.Models;
using Blog_Website.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository _repo;

        public HomeController(ILogger<HomeController> logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            List<Post> postsList = _repo.GetAllPosts();
            return View(postsList); // returns a view with all the posts
        }

        [HttpGet]
        public IActionResult View(int id) // GET HTTP METHOD
        {
            var obj = _repo.GetPost(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Post(int id) // GET HTTP METHOD
        {
            var obj = _repo.GetPost(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Post(Post post) // POST HTTP METHOD
        {
            _repo.AddPost(post);
            _repo.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id) // GET HTTP METHOD
        {
            if (id == 0)
            {
                return View(new PostViewModel());
            }
            else
            {
                var obj = _repo.GetPost(id);

                return View(new PostViewModel
                {
                    Id = obj.Id,
                    Title = obj.Title,
                    Body = obj.Body,
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostViewModel obj) //POST-Delete HTTP METHOD, works with the database
        {
            var post = new Post
            {
                Id = obj.Id,
                Title = obj.Title,
                Body = obj.Body,
                Image = ""
            };

            if (ModelState.IsValid)
            {
                _repo.UpdatePost(post);
                _repo.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET-Delete Expense, works with the view
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var obj = _repo.GetPost(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-Delete Expense, works with the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            _repo.RemovePost(id);
            _repo.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}