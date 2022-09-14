namespace Article.Api.Domain.Models
{
    public class BlogArticleComment
    {
        public BlogArticleComment()
        {
            Author = string.Empty;
            Content = string.Empty;
            Created = DateTimeOffset.UtcNow;
        }

        public BlogArticleComment(string author, string content)
        {
            Author = author;
            Content = content;
            Created = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTimeOffset Created { get; set; }

        public Guid BlogArticleId { get; set; }
        public BlogArticle BlogArticle { get; set; }
    }
}
