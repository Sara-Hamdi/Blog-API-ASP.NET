namespace Blog.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Guid PostId { get; set; }
        public DateTime PublishedDate { get; set; }
        
        public virtual Post Post { get; set; }
    }
}
