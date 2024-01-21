using Data.Entities;
using Post_MVC.Models;

namespace Post_MVC.Mappers
{
    public class PostMapper
    {
        public static Post FromEntity(PostEntity entity)
        {
            return new Post()
            {
                Id = entity.Id,
                Content = entity.Content,
                Author = entity.Author,
                Comment = entity.Comment,
                Date = entity.Date,
                Tags = (Tags)Enum.Parse(typeof(Tags), entity.Tags),
            };
        }

        public static PostEntity ToEntity(Post model)
        {
            return new PostEntity()
            {
                Id = model.Id,
                Content = model.Content,
                Author = model.Author,
                Comment = model.Comment,
                Date = model.Date,
                Tags = model.Tags.ToString(),
            };
        }
    }
}
