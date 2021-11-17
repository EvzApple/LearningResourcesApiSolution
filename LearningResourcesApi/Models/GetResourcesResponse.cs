using System.ComponentModel.DataAnnotations;

namespace LearningResourcesApi.Models
{
    public class GetResourcesResponse : GetResponseCollection<ResourceItem>
    {
    }

    public class ResourceItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string SuggestedBy { get; set; }
        [Required]
        public string Format { get; set; }
        public string Link { get; set;  }
        public DateTime? WatchedOn { get; set; }
    }
}
