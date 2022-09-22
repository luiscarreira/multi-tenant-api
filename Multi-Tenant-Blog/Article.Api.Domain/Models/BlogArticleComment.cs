using HotChocolate.Types;
using HotChocolate;

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

        [GraphQLType(typeof(NonNullType<StringType>))]
        public string Author { get; set; }

        [GraphQLType(typeof(NonNullType<StringType>))]
        public string Content { get; set; }

        [GraphQLType(typeof(NonNullType<DateTimeType>))]
        public DateTimeOffset Created { get; set; }

        [GraphQLNonNullType]
        public Guid BlogArticleId { get; set; }

        //public BlogArticle BlogArticle { get; set; }
    }
}
