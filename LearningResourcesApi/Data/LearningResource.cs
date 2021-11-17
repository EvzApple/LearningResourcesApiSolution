namespace LearningResourcesApi.Data
{
    public class LearningResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Author { get; set; }
        public string? SuggestedBy { get; set; }
        public string Format { get; set; }
        public string? Link { get; set; }
        public DateTime? WatchedOn { get; set; }
    }
}
