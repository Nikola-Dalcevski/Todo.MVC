using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts
{
    public interface IUserRepository
    {
        User GetById(string id);
        IEnumerable<User> GetAll();
        User GetByEmail(string email);
        int Insert(User item);
        int Update(User item);
        int Remove(string id);
    }
}
