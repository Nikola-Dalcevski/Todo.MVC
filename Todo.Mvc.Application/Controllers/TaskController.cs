using BusinessLayer.Contracts;
using BusinessLayer.ViewModels;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Mvc.Application.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskServices _taskServices;
        private readonly ITodoTaskTypeServices _typeServices;
        private readonly ISubTaskService _subTaskServices;

        public TaskController(
            ITaskServices taskServices,
            ITodoTaskTypeServices typeServices,
            ISubTaskService subTaskServices
          
            )
        {
            _taskServices = taskServices;
            _typeServices = typeServices;
            _subTaskServices = subTaskServices;
        }

        public IActionResult GetById(int id)
        {
            var task = _taskServices.GetById(id);
            var subTasks = _subTaskServices.GetAll(id);
            ViewBag.SubTasks = subTasks;
            return View(task);
        }

        public IActionResult GetAll()
        {
            var tasks = _taskServices.GetAll();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            var types = _typeServices.GetAll();
            ViewBag.Types = types;
            return View();
        }

        [HttpPost]
        public IActionResult CreateTask(TodoTaskViewModel model)
        {
            _taskServices.AddTask(model);
            
            return RedirectToAction("GetAll", "Task");

        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var types = _typeServices.GetAll();
            ViewBag.Types = types;
            var model = _taskServices.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditTask(TodoTaskViewModel model)
        {
            _taskServices.EditTask(model);
            return RedirectToAction("GetAll", "Task");
        }

        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var task = _taskServices.GetById(id);      
            return View(task);
        }

        [HttpPost]
        public IActionResult DeleteTask(TodoTaskViewModel model)
        {
            _taskServices.DeleteTask(model.Id);

            return RedirectToAction("GetAll");
            }


        }
}