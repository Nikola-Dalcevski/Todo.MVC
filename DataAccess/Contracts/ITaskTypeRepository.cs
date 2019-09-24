using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts
{
    public interface ITaskTypeRepository : IRepository<TodoTaskType>
    {
        TodoTaskType GetByName(string name);
    }
}
