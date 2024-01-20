using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Post_MVC.Models
{
    public enum Tags
    {
        [Display(Name = "Nowość")]
        New,
        [Display(Name = "Technologia")]
        Tech,
        [Display(Name = "Sport")]
        Sport,
        [Display(Name = "Zdrowie")]
        Health,
        [Display(Name = "Polityka")]
        Politics,
    }

    public class Post
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Zawartość")]
        [Required(ErrorMessage = "Musisz podać zawartość wpisu!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Post jest zbyt długi!")]
        public required string Content { get; set; }

        [Display(Name = "Autor wpisu")]
        [Required(ErrorMessage = "Musisz podać nick autora wpisu!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Nick jest zbyt długi!")]
        public required string Author { get; set; }

        [DataType(DataType.Date)]
        public required DateTime Date { get; set; }

        [Display(Name = "Komentarz")]
        [Required(ErrorMessage = "Komentarz jest wymagany!")]
        public required string Comment { get; set; }

        [Display(Name = "Tagi")]
        [Required(ErrorMessage = "Musisz podać tag autora wpisu!")]
        public required Tags Tags { get; set; }
    }
}