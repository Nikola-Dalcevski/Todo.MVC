using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Contracts;
using BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Mvc.Application.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            _userServices.RegisterUser(model);
            return RedirectToAction("GetAll", "Task");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel model)
        {
            _userServices.LogInUser(model);
            return RedirectToAction("GetAll", "Task");
        }


        public IActionResult Logout()
        {
            _userServices.Logout();
            return RedirectToAction("GetAll", "Task");
        }

        [HttpGet]
        public IActionResult GetUser(string id)
        {
            var user = _userServices.GetUserById(id);
            return View(user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userServices.GetAllUsers();
            return View(users);
        }
    }
}