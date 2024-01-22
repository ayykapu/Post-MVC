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
                PostId = entity.PostId,
                PostAuthor = entity.PostAuthor,
                PostContent = entity.PostContent,
                TagId = entity.TagId,
                PostDate = entity.PostDate,
                Tag = entity.Tag,
            };
        }

        public static PostEntity ToEntity(Post model)
        {
            return new PostEntity()
            {
                PostId = model.PostId,
                PostAuthor = model.PostAuthor,
                PostContent = model.PostContent,
                TagId = model.TagId,
                PostDate = model.PostDate,
                Tag = model.Tag,
            };
        }
    }
}
