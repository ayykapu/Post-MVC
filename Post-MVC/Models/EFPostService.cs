using Data.Entities;
using Data;
using Post_MVC.Mappers;
using Post_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Post_MVC.Models
{
    public class EFPostService : IPostService
    {
        private AppDbContext _context;

        public EFPostService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Post item)
        {
            var e = _context.Posts.Add(PostMapper.ToEntity(item));
            _context.SaveChanges();
            return e.Entity.PostId;
        }

        public void Delete(int id)
        {
            var find = _context.Posts.Find(id);
            if (find != null)
            {
                _context.Posts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Post> FindAll()
        {
            return _context
                 .Posts
                 .Include(p => p.Tag)
                 .Select(e => PostMapper.FromEntity(e))
                 .ToList();
        }

        public Post? FindById(int id)
        {
            var find = _context.Posts.Include(p => p.Tag).SingleOrDefault(p => p.PostId == id);
            return find is null ? null : PostMapper.FromEntity(find);
        }

        public List<Post> FindByTag(int tagId)
        {
            return _context.Posts.Include(p => p.Tag).Where(o => o.TagId == tagId).Select(o => PostMapper.FromEntity(o)).ToList();
        }

        public PagingList<Post> FindPage(int page, int size, List<Post> posts)
        {
            return PagingList<Post>.Create(
                  (p, s) => posts.OrderBy(c => c.PostDate).Skip((p - 1) * s).Take(s)
                  , page, size, posts.Count()
              );
        }

        public void Update(Post model)
        {
            var entity = PostMapper.ToEntity(model);
            _context.Update(entity);
            _context.SaveChanges();
        }

    }
}