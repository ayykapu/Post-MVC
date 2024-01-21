using Data;
using Data.Entities;
using Post_MVC.Mappers;

namespace Post_MVC.Models
{
    public class EFPostService : IPostService
    {
        private AppDbContext _context;
        public EFPostService(AppDbContext context)
        {
            _context = context;
        }
        public int Add(Post post)
        {
            var e = _context.Posts.Add(PostMapper.ToEntity(post));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            PostEntity? find = _context.Posts.Find(id);
            if (find != null) 
            {
                _context.Posts.Remove(find);
            }
        }

        public List<Post> FindAll()
        {
            return _context.Posts.Select(e => PostMapper.FromEntity(e)).ToList(); 
        }

        public Post? FindById(int id)
        {
            return PostMapper.FromEntity(_context.Posts.Find(id));
        }

        public void Update(Post post)
        {
            _context.Posts.Update(PostMapper.ToEntity(post));
        }
    }
}
