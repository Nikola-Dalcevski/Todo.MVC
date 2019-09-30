using BusinessLayer.ViewModels;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Mvc.Application.Controllers
{
    public class SubTaskController : Controller
    {
        private readonly ISubTaskService _subTaskServices;

        public SubTaskController(ISubTaskService subTaskServices)
        {
           _subTaskServices = subTaskServices;
        }
        public IActionResult GetById(int id)
        {
            var subTask = _subTaskServices.GetById(id);
            return View(subTask);
        }

        [Authorize(Roles = "user")]
        [AllowAnonymous]
        public IActionResult GetAll(int id)
        {
            var subTasks = _subTaskServices.GetAll(id);
            return PartialView(subTasks);
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public IActionResult AddSubTask(int taskId )
        {

            ViewBag.TaskId = taskId;
            return View();
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public IActionResult AddSubTAsk(SubTaskViewModel model)
        {
            _subTaskServices.AddSubTask(model);
            return RedirectToAction("GetById", "Task", new { id =  model.TaskId });
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public IActionResult EditSubTask(int id)
        {
            var task = _subTaskServices.GetById(id);
            return View(task);
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public IActionResult EditSubTask(SubTaskViewModel model)
        {
            _subTaskServices.EditSubTAsk(model);
            return RedirectToAction("GetById", "Task", new { id = model.TaskId  });
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public IActionResult DeleteSubTask(int id)
        {
            var task = _subTaskServices.GetById(id);
            return View(task);
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public IActionResult DeleteSubTask(SubTaskViewModel model)
        {
            _subTaskServices.DeleteSubTask(model.Id);
            return RedirectToAction("GetById", "Task", new { id = model.TaskId });
        }
    }
}