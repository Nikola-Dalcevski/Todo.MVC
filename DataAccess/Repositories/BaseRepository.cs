namespace DataAccess.Repositories
{
    public class BaseRepository
    {
        protected readonly TodoDbContext _context;

        public BaseRepository(TodoDbContext context)
        {
            _context = context;
        }
    }
}
