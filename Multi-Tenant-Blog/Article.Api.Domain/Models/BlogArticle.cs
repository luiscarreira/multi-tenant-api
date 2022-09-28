namespace Article.Api.Domain.Models
{
    public class BlogArticle
    {
        public BlogArticle()
        {
            Title = string.Empty;
            Content = string.Empty;
            Author = string.Empty;
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public BlogArticle(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public string Author { get; set; }
        
        public DateTimeOffset CreatedDate { get; set; }
        
        public DateTimeOffset? UpdatedDate { get; set; }

    }
}
