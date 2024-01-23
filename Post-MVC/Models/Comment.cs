using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Post_MVC.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public required string CommentAuthor { get; set; }
        public required string CommentContent { get; set; }
        public required DateTime CommentDate { get; set; }
        public int PostId { get; set; }
    }
}

