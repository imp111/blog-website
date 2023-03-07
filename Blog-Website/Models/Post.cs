using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog_Website.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Title: ")]
        public string Title { get; set; } = "";

        [DisplayName("Body: ")]
        [Required]
        public string Body { get; set; } = "";

        public string? Image { get; set; }

        public DateTime Created { get; set; } = DateTime.Now.Date;
    }
}
