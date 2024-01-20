namespace Post.Models
{
    public interface IPostService
    {
        int Add(PostClass item);
        void Delete(int id);
        void Update(PostClass item);
        PostClass? FindById(int id);
        List<PostClass> FindAll();
    }
}