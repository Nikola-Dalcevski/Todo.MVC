using BusinessLayer.Contracts;
using BusinessLayer.ViewModels;
using DataAccess.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Todo.Mvc.Application.Controllers
{
    
    public class TaskController : Controller
    {
        
        private readonly ITaskServices _taskServices;
        private readonly ITodoTaskTypeServices _typeServices;
        private readonly ISubTaskService _subTaskServices;
        //TODO: its not good to hafe reference to domain model user
        private readonly UserManager<User> _UserManager;

        public TaskController(
            ITaskServices taskServices,
            ITodoTaskTypeServices typeServices,
            ISubTaskService subTaskServices,
            UserManager<User> _userManager         
            )
        {
            _taskServices = taskServices;
            _typeServices = typeServices;
            _subTaskServices = subTaskServices;
            _UserManager = _userManager;

        }

        [Authorize(Roles = "user")]
        public IActionResult GetById(int id)
        {

          
            var task = _taskServices.GetById(id);
            var subTasks = _subTaskServices.GetAll(id);
            ViewBag.SubTasks = subTasks;
            return View(task);
        }

        [Authorize(Roles = "user")]
        [AllowAnonymous]
        public IActionResult GetAll(string id )
        {
            //if (string.IsNullOrEmpty(id))
            //{
            //    id = currentUserId;
            //}
            var userId = _UserManager.GetUserId(HttpContext.User);
            //ViewBag.UserId = userId;
            ViewBag.UserId = string.IsNullOrEmpty(id) ? userId : id;
            var tasks = _taskServices.GetAll(userId);
            return View(tasks);
        }

        [Authorize( Roles ="user")]
        [HttpGet]
        public IActionResult CreateTask(string id)
        {

            var types = _typeServices.GetAll();
            ViewBag.Types = types;
            ViewBag.UserId = id;
            return View();
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public IActionResult CreateTask(TodoTaskViewModel model)
        {   
            _taskServices.AddTask(model);            
            return RedirectToAction("GetAll", "Task", new {id = model.UserId });
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var types = _typeServices.GetAll();
            ViewBag.Types = types;
            var model = _taskServices.GetById(id);
            return View(model);
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public IActionResult EditTask(TodoTaskViewModel model)
        {
            _taskServices.EditTask(model);
            return RedirectToAction("GetAll", "Task", new { id = model.UserId});
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var task = _taskServices.GetById(id);      
            return View(task);
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public IActionResult DeleteTask(TodoTaskViewModel model)
        {
            _taskServices.DeleteTask(model.Id);

            return RedirectToAction("GetAll", "Task", new {id = model.UserId });
            }


        }
}