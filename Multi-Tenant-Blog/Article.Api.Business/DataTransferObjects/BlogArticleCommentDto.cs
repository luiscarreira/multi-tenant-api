using HotChocolate.Types;
using HotChocolate;

namespace Article.Api.Business.DataTransferObjects
{
    public class BlogArticleCommentDto
    {
        public Guid? Id { get; set; }

        [GraphQLType(typeof(NonNullType<StringType>))]
        public string? Author { get; set; }

        [GraphQLType(typeof(NonNullType<StringType>))]
        public string? Content { get; set; }

        [GraphQLType(typeof(DateTimeType))]
        public DateTimeOffset? Created { get; set; }

        [GraphQLType(typeof(Guid?))]
        public Guid? BlogArticleId { get; set; }
    }
}
