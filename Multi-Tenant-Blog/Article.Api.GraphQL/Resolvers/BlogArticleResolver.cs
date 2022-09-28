using Article.Api.Business.Contracts;
using Article.Api.Business.DataTransferObjects;

namespace Article.Api.GraphQL.Resolvers
{
    public class BlogArticleResolver
    {
        public BlogArticleDto? GetBlogArticle([Service] IBlogArticleService blogArticleService, [Parent] BlogArticleCommentDto articleComment)
        {
            return articleComment.BlogArticleId.HasValue ? blogArticleService.GetById(articleComment.BlogArticleId.Value) : default;
        }
    }
}
