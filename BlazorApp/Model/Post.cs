using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }

    }
}
