using BusinessLayer.ViewModels;
using DataAccess.Contracts;
using Domain.Models;

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

            int typeId = int.Parse(model.Type);
            var taskType = _typeReposiotry.GetById(typeId);

            return new TodoTask()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Priority = model.Priority,
                TodoStatus = model.TodoStatus,
                TaskTypeId = taskType.Id,
                UserId = model.UserId             
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
                Type = taskType.Title,
                UserId = model.UserId              
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
                Id = model.Id,
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
