namespace Blog.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
