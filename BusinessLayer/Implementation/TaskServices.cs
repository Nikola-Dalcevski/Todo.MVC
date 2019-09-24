using BusinessLayer.Contracts;
using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataAccess.Contracts;
using DataAccess.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void AddTask(TodoTaskViewModel model)
        {
            var task = _mapper.TaskViewModelToTodoTask(model);
            _taskRepository.Insert(task);
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

        public List<TodoTaskViewModel> GetAll()
        {
            var tasks = _taskRepository.GetAll();
            List<TodoTaskViewModel> viewTasks = new List<TodoTaskViewModel>();
            foreach ( var task in tasks)
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
            //viewTask.Type = _mapper.IntTaskTypeToString(task.TaskType);
            return viewTask;
        }
    }
}
