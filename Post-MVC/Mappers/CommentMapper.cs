using Data.Entities;
using Post_MVC.Models;

namespace Post_MVC.Mappers
{
    public class CommentMapper
    {
        public static Comment FromEntity(CommentEntity entity)
        {
            return new Comment()
            {
                CommentId = entity.CommentId,
                CommentAuthor = entity.CommentAuthor,
                CommentContent = entity.CommentContent,
                CommentDate = entity.CommentDate,
                PostId = entity.PostId,
            };
        }

        public static CommentEntity ToEntity(Comment model)
        {
            return new CommentEntity()
            {
                CommentId = model.CommentId,
                CommentAuthor = model.CommentAuthor,
                CommentContent = model.CommentContent,
                CommentDate = model.CommentDate,
                PostId = model.PostId,
            };
        }
    }
}
