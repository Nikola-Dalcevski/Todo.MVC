using BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts
{
    public interface ISubTaskService
    {
        SubTaskViewModel GetById(int id);
        List<SubTaskViewModel> GetAll(int id);
        void AddSubTask(SubTaskViewModel model);
        void EditSubTAsk(SubTaskViewModel model);
        void DeleteSubTask(int id);

    }
}
