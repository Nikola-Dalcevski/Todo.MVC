using DataAccess.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementation
{
    public class TaskTypeServices : ITodoTaskTypeServices
    {
        private readonly ITaskTypeRepository _typeRepository;

        public TaskTypeServices(ITaskTypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public List<TodoTaskType> GetAll()
        {
            return _typeRepository.GetAll().ToList();
        }
    }
}
