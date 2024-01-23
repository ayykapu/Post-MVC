using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Post_MVC.Models
{

    public class Post
    {
        [HiddenInput]
        public int PostId { get; set; }
        [Required]
        [Display(Name = "Podaj treść posta.")]
        [MaxLength(length: 200, ErrorMessage = "Post jest zbyt długi.")]
        public string PostContent { get; set; }
        [Required]
        [Display(Name = "Podaj autora posta.")]
        [MaxLength(length: 30, ErrorMessage = "Nazwa autora jest zbyt długa.")]
        public string PostAuthor { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
        public int TagId { get; set; }
        public TagEntity? Tag { get; set; }
    }
}