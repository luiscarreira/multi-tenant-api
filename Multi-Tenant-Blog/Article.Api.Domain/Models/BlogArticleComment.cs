namespace Article.Api.Domain.Models
{
    public class BlogArticleComment
    {
        public BlogArticleComment()
        {
            Author = string.Empty;
            Content = string.Empty;
            Created = DateTimeOffset.UtcNow;
            BlogArticleId = Guid.Empty;
        }

        public BlogArticleComment(Guid blogArticleId)
        {
            Author = string.Empty;
            Content = string.Empty;
            Created = DateTimeOffset.UtcNow;
            BlogArticleId = blogArticleId;
        }

        public BlogArticleComment(Guid blogArticleId, string author, string content)
        {
            Author = author;
            Content = content;
            Created = DateTimeOffset.UtcNow;
            BlogArticleId = blogArticleId;
        }

        public Guid Id { get; set; }
        
        public string Author { get; set; }
        
        public string Content { get; set; }
        
        public DateTimeOffset Created { get; set; }
        
        public Guid BlogArticleId { get; set; }
    }
}
