using BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts
{
    public interface ITaskServices
    {
        TodoTaskViewModel GetById(int id);
        List<TodoTaskViewModel> GetAll(string id);
        string AddTask(TodoTaskViewModel model);
        void EditTask(TodoTaskViewModel model);
        void DeleteTask(int id);
    }
}
