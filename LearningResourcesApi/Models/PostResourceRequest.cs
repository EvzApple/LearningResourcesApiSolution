using System.ComponentModel.DataAnnotations;

namespace LearningResourcesApi.Models
{
    public class PostResourceRequest
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string? SuggestedBy { get; set; }
        [Required]
        public string Format { get; set; }
        public string? Link { get; set; }

    }
}
