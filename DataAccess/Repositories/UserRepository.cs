using DataAccess.Contracts;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository : BaseRepository , IUserRepository
    {
        public UserRepository(TodoDbContext context)
            : base(context)
        {

        }

        public IEnumerable<User> GetAll()
        {
           return _context.Users;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(x => x.Email == email);
        }

        public User GetById(string id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(User item)
        {
            _context.Users.Add(item);
            return _context.SaveChanges();
        }

        public int Remove(string id)
        {
            var user = GetById(id);
            if(user == null)
            {
                return -1;
            }
            _context.Users.Remove(user);
            
            return _context.SaveChanges();
        }

        public int Update(User item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public User GerByEmail(string email)
        {
           return _context.Users.SingleOrDefault(x => x.Email == email);
        }
    }
}
