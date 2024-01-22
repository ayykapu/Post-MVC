using Data.Entities;

namespace Post_MVC.Models
{
    public interface IPostService
    {
        int Add(Post item);
        void Delete(int id);
        Post? FindById(int id);
        List<Post> FindAll();
        void Update(Post item);
        List<Post> FindByTag(int tagId);
        PagingList<Post> FindPage(int page, int size, List<Post> posts);
    }
}