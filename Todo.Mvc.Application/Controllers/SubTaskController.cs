using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.ViewModels;
using DataAccess.Contracts;
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

        public IActionResult GetAll(int id)
        {
            var subTasks = _subTaskServices.GetAll(id);
            return PartialView(subTasks);
        }

        [HttpGet]
        public IActionResult AddSubTask(int id )
        {
            //var Id = id;
            ViewBag.TaskId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddSubTAsk(SubTaskViewModel model)
        {
            _subTaskServices.AddSubTask(model);
            return RedirectToAction("GetAll", "Task");
        }

        [HttpGet]
        public IActionResult EditSubTask(int id)
        {
            var task = _subTaskServices.GetById(id);
            return View(task);
        }

        [HttpPost]
        public IActionResult EditSubTask(SubTaskViewModel model)
        {
            _subTaskServices.EditSubTAsk(model);
            return RedirectToAction("GetAll", "SubTask");
        }

        [HttpGet]
        public IActionResult DeleteSubTask(int id)
        {
            var task = _subTaskServices.GetById(id);
            return View(task);
        }

        [HttpPost]
        public IActionResult DeleteSubTask(SubTaskViewModel model)
        {
            _subTaskServices.DeleteSubTask(model.Id);
            return RedirectToAction("GetAll", "SubTask");
        }
    }
}