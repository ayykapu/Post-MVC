namespace Post_MVC.Models
{
    public interface IPostService
    {
        int Add(Post item);
        void Delete(int id);
        void Update(Post item);
        Post? FindById(int id);
        List<Post> FindAll();
    }
}