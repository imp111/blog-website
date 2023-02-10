using Blog_Website.Data.Repository;
using Blog_Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Website.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IRepository _repo;

        public PanelController(IRepository repo)
        {
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
                return NotFound();
            }

            var obj = _repo.GetPost(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post obj) //POST-Delete HTTP METHOD, works with the database
        {
            if (ModelState.IsValid)
            {
                _repo.UpdatePost(obj);
                _repo.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);
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
    }
}
