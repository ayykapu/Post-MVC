using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PostEntity
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public string PostContent { get; set; }
        [Required]
        public string PostAuthor { get; set; }
        [Required]
        public DateTime PostDate { get; set; }
        [Required]
        public int TagId {get; set; }
        [Required]
        public TagEntity? Tag { get; set; }
        public ISet<CommentEntity>? Comments { get; set; }
    }
}
