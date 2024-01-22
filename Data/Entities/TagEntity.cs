using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class TagEntity
    {
        [Key]
        public int TagId { get; set; }
        [Required]
        public string TagTitle { get; set; }
        public ISet<PostEntity>? Posts { get; set;}
    }
}
