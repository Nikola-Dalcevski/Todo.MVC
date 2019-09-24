using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts
{
    public interface ITodoTaskTypeServices
    {
        List<TodoTaskType> GetAll();
    }
}
