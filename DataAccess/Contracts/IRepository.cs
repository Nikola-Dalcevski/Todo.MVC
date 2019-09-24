using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        int Insert(T item);
        int Update(T item);
        int Remove(int id);
    }
}
