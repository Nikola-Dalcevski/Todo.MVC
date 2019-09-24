using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataAccess.Contracts;
using DataAccess.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementation
{
    public class SubTaskServices : ISubTaskService
    {
        private readonly IRepository<SubTodoTask> _subTaskRepository;
        private readonly MapperProfile _mapper;

        public SubTaskServices(IRepository<SubTodoTask> subTaskRepository, MapperProfile mapper)
        {
            _subTaskRepository = subTaskRepository;
            _mapper = mapper;
        }
        public void AddSubTask(SubTaskViewModel model)
        {
            var subTask = _mapper.ViewSubTaskToSubTask(model);
            _subTaskRepository.Insert(subTask);
           
        }

        public void DeleteSubTask(int id)
        {
            _subTaskRepository.Remove(id);
        }

        public void EditSubTAsk(SubTaskViewModel model)
        {
            var subTask = _mapper.ViewSubTaskToSubTask(model);
            _subTaskRepository.Update(subTask);
        }

        public List<SubTaskViewModel> GetAll(int id)
        {
            List<SubTodoTask> subTasks = _subTaskRepository.GetAll().Where(x => x.TaskId == id).ToList();
            List<SubTaskViewModel> viewSubTasks = new List<SubTaskViewModel>();
            foreach (var subTask in subTasks)
            {
                viewSubTasks.Add(_mapper.SubTaskToViewSubTask(subTask));
            }
            return viewSubTasks;
        }

        public SubTaskViewModel GetById(int id)
        {
            var subTask = _subTaskRepository.GetById(id);
            if(subTask == null)
            {
                throw new ArgumentException($"sub task with id : {id} does not exists");
            }
            var viewSubTask = _mapper.SubTaskToViewSubTask(subTask);
            return viewSubTask;
        }
    }
}
