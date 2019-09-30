using DataAccess.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class TodoTaskRepository : BaseRepository, IRepository<TodoTask>
    {
        public TodoTaskRepository(TodoDbContext context)
            : base(context)
        {

        }

        public IEnumerable<TodoTask> GetAll()
        {
            return _context.Tasks;
        }

        public TodoTask GetById(int id)
        {
            return _context.Tasks.SingleOrDefault(x => x.Id == id);
        }


        public int Insert(TodoTask item)
        {
            _context.Tasks.Add(item);
            return _context.SaveChanges();
        }

        public int Remove(int id)
        {
            var task = GetById(id);
            if(task == null)
            {
                return -1;
            }
            _context.Tasks.Remove(task);
            return _context.SaveChanges();
        }

        public int Update(TodoTask item)
        {

            _context.Entry(item).State = EntityState.Modified;
           return _context.SaveChanges();
          
        }
    }
}
