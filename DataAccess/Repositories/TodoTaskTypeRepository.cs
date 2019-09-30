using DataAccess.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class TodoTaskTypeRepository : BaseRepository, ITaskTypeRepository
    {

        public TodoTaskTypeRepository(TodoDbContext context)
            :base(context)
        {

        }
        public IEnumerable<TodoTaskType> GetAll()
        {
            return _context.Types;
        }

        public TodoTaskType GetById(int id)
        {
            return _context.Types.SingleOrDefault(x => x.Id == id);
        }


        public int Insert(TodoTaskType item)
        {
            _context.Types.Add(item);
            return _context.SaveChanges();
        }

        public int Remove(int id)
        {
            var type = GetById(id);
            if (type == null)
            {
                return -1;
            }
            _context.Types.Remove(type);
            return _context.SaveChanges();
        }

        public int Update(TodoTaskType item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public TodoTaskType GetByName(string name)
        {
           return  _context.Types.SingleOrDefault(x => x.Title == name);
        }
    }
}
