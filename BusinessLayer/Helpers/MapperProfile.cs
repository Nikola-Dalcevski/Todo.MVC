using AutoMapper;
using BusinessLayer.ViewModels;
using DataAccess.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Helpers
{
    public class MapperProfile 
    {
        private readonly ITaskTypeRepository _typeReposiotry;

        public MapperProfile(ITaskTypeRepository typeReposiotry)
        {
            _typeReposiotry = typeReposiotry;
        }

        public User RegisterToUserModel(RegisterUserViewModel model)
        {
            return new User
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = model.Password,     
            };
        }

        public UserViewModel UserToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public TodoTask TaskViewModelToTodoTask(TodoTaskViewModel model)
        {
            var taskType = _typeReposiotry.GetByName(model.Type);
            return new TodoTask
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Priority = model.Priority,
                TodoStatus = model.TodoStatus,
                TaskTypeId = taskType.Id
            };
        }
        public TodoTaskViewModel TodoTaskToTaskViewModel(TodoTask model)
        {
            var taskType = _typeReposiotry.GetById(model.TaskTypeId);
            return new TodoTaskViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Priority = model.Priority,
                TodoStatus = model.TodoStatus,
                Type = taskType.Title
                //TODO: need to finis with type hint to call type service metod get type

            };
        }

        public SubTaskViewModel SubTaskToViewSubTask(SubTodoTask model)
        {
            return new SubTaskViewModel
            {
                Id = model.Id,
                Title = model.Title,
                SubTodoStatus = model.SubTodoStatus,
                Description = model.Description,
                TaskId = model.TaskId
                
                
            };
        }

        public SubTodoTask ViewSubTaskToSubTask(SubTaskViewModel model)
        {
            return new SubTodoTask
            {
                
                Title = model.Title,
                SubTodoStatus = model.SubTodoStatus,
                Description = model.Description,
                TaskId = model.TaskId
                

            };
        }


        public string IntTaskTypeToString(int type)
        {
            var taskType = _typeReposiotry.GetById(type);
            return taskType.Title;
        }
    }
}
