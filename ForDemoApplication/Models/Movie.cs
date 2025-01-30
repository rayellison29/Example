using System.ComponentModel.DataAnnotations;

namespace ForDemoApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        public string? LeadStars { get; set; }
    }
}

