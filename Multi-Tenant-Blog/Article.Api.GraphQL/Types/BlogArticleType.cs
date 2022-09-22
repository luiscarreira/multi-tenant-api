using Article.Api.Domain.Models;
using Article.Api.GraphQL.Resolvers;

namespace Article.Api.GraphQL.Types
{
    public class BlogArticleType : ObjectType<BlogArticle>
    {
        protected override void Configure(IObjectTypeDescriptor<BlogArticle> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Title).Type<StringType>();
            descriptor.Field(a => a.Content).Type<StringType>();
            descriptor.Field(a => a.Author).Type<StringType>();
            descriptor.Field(a => a.CreatedDate).Type<DateTimeType>();
            descriptor.Field(a => a.UpdatedDate).Type<DateTimeType>();

            descriptor.Field<BlogArticleCommentResolver>(b => b.GetBlogArticleComments(default));
        }
    }
}
