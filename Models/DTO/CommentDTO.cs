namespace Blog.Models.DTO
{
    public class CommentDTO
    {
        
        public string Content { get; set; }
        public string Author { get; set; }
        public Guid PostId { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
