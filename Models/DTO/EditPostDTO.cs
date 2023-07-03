namespace Blog.Models.DTO
{
    public class EditPostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
