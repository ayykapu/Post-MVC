using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class CommentEntity
    {
        [Key] 
        public int CommentId { get; set; }

        [Required]
        [MaxLength(30)] 
        public string CommentAuthor { get; set; }

        [MaxLength(300)]
        [Required] 
        public string CommentContent { get; set; }

        [Required] 
        public DateTime CommentDate { get; set; }

        [Required] 
        public int PostId { get; set; }

        [Required] 
        public PostEntity? Post { get; set; }
    }
}
