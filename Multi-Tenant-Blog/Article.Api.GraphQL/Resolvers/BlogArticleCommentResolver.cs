using Article.Api.Business.Contracts;
using Article.Api.Business.DataTransferObjects;

namespace Article.Api.GraphQL.Resolvers
{
    public class BlogArticleCommentResolver
    {
        public IEnumerable<BlogArticleCommentDto>? GetBlogArticleComments([Service] IBlogArticleCommentService blogArticleCommentService, [Parent] BlogArticleDto article)
        {
            return article.Id.HasValue ? blogArticleCommentService.GetAll(article.Id.Value) : default;
        }
    }
}
