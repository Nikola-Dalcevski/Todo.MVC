using BusinessLayer.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts
{
    public interface IUserServices
    {
        UserViewModel GetUserById(string id);
        List<UserViewModel> GetAllUsers();
        void RegisterUser(RegisterUserViewModel model);
        string LogInUser(LoginUserViewModel model);
        void Logout();
        UserViewModel GetByEmail(string email);
        
    }
}
