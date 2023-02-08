using Blog_Website.Models;
using Blog_Website.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Website.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;

        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false); // get the username and password from the viewmodel and sign in

            return RedirectToAction("Index", "Home"); // return to the index action of the home controller
        } 

        [HttpGet]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync(); // sign out

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(LoginViewModel login)
        {
            return RedirectToAction("Index", "Home"); // return to the index action of the home controller
        }

    }
}
