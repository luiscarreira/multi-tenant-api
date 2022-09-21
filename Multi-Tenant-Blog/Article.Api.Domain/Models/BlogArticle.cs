using HotChocolate;
using HotChocolate.Types;

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

        [GraphQLType(typeof(NonNullType<StringType>))]
        public string Title { get; set; }

        [GraphQLType(typeof(NonNullType<StringType>))]
        public string Content { get; set; }

        [GraphQLType(typeof(NonNullType<StringType>))]
        public string Author { get; set; }

        [GraphQLType(typeof(NonNullType<DateTimeType>))]
        public DateTimeOffset CreatedDate { get; set; }

        [GraphQLType(typeof(DateTimeType))]
        public DateTimeOffset? UpdatedDate { get; set; }

        [GraphQLIgnore]
        public List<BlogArticleComment> Comments { get; } = new();
    }
}
