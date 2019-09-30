using BusinessLayer.Contracts;
using BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Todo.Mvc.Application.Controllers
{
    public class UserController : Controller 
    {
        private readonly IUserServices _userServices;
        private  static string currentUser;
      
        public UserController(IUserServices userServices )
        {
            _userServices = userServices;
   
        }

        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            _userServices.RegisterUser(model);
            return RedirectToAction("GetAll", "Task");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginUserViewModel model)
        {
             string userId = _userServices.LogInUser(model);
            
            return RedirectToAction("GetAll", "Task", new { id = userId});
        }

        [AllowAnonymous]
        public IActionResult Logout()
        {
            _userServices.Logout();
            return RedirectToAction("GetAll", "Task");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetUser(string id)
        {
            var user = _userServices.GetUserById(id);
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userServices.GetAllUsers();
            return View(users);
        }
    }
}