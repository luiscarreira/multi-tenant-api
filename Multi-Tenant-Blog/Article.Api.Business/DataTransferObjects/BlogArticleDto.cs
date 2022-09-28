using HotChocolate;
using HotChocolate.Types;

namespace Article.Api.Business.DataTransferObjects
{
    public class BlogArticleDto
    {
        public Guid? Id { get; set; }

        [GraphQLType(typeof(NonNullType<StringType>))]
        public string? Title { get; set; }

        [GraphQLType(typeof(NonNullType<StringType>))]
        public string? Content { get; set; }

        [GraphQLType(typeof(NonNullType<StringType>))]
        public string? Author { get; set; }

        [GraphQLType(typeof(DateTimeType))]
        public DateTimeOffset? CreatedDate { get; set; }

        [GraphQLType(typeof(DateTimeType))]
        public DateTimeOffset? UpdatedDate { get; set; }

        
    }
}
