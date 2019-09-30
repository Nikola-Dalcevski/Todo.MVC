using BusinessLayer.Contracts;
using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataAccess.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Implementation
{
    class TaskServices : ITaskServices
    {
        private readonly IRepository<TodoTask> _taskRepository;
        private readonly MapperProfile _mapper;

        public TaskServices(IRepository<TodoTask> taskRepository, MapperProfile mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public string AddTask(TodoTaskViewModel model)
        {
            var task = _mapper.TaskViewModelToTodoTask(model);
            _taskRepository.Insert(task);
            return model.UserId;
        }

        public void DeleteTask(int id)
        {
            _taskRepository.Remove(id);
        }

        public void EditTask(TodoTaskViewModel model)
        {
            var task = _mapper.TaskViewModelToTodoTask(model);
            _taskRepository.Update(task);
        }

        public List<TodoTaskViewModel> GetAll(string id)
        {
            var tasks = _taskRepository.GetAll();
            var userTasks = tasks.Where(x => x.UserId == id);
            List<TodoTaskViewModel> viewTasks = new List<TodoTaskViewModel>();
            foreach ( var task in userTasks)
            {
                viewTasks.Add(_mapper.TodoTaskToTaskViewModel(task));

            }

            return viewTasks;
        }

        public TodoTaskViewModel GetById(int id)
        {
            var task = _taskRepository.GetById(id);
            if(task == null)
            {
                throw new ArgumentException($"task with id {id} does not exists");
            }
            var viewTask = _mapper.TodoTaskToTaskViewModel(task);
            return viewTask;
        }
    }
}
