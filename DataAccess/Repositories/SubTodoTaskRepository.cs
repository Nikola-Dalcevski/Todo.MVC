using DataAccess.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class SubTodoTaskRepository : BaseRepository, IRepository<SubTodoTask>
    {
        public SubTodoTaskRepository(TodoDbContext context)
            :base(context)
        {

        }
        public IEnumerable<SubTodoTask> GetAll()
        {
            return _context.SubTasks;
        }

        public SubTodoTask GetById(int id)
        {
            return _context.SubTasks.SingleOrDefault(x => x.Id == id);
        }


        public int Insert(SubTodoTask item)
        {
            _context.SubTasks.Add(item);
            return _context.SaveChanges();
        }

        public int Remove(int id)
        {
            var subTask = GetById(id);
            if (subTask == null)
            {
                return -1;
            }
            _context.SubTasks.Remove(subTask);
            return _context.SaveChanges();
        }

        public int Update(SubTodoTask item)
        {
            _context.SubTasks.Update(item);
            return _context.SaveChanges();
        }

   
    }
}
