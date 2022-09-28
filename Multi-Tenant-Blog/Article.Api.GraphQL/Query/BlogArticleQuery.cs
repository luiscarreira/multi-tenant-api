using Article.Api.Business.Contracts;
using Article.Api.Business.DataTransferObjects;
using Article.Api.Domain.Models;
using HotChocolate.Subscriptions;

namespace Article.Api.GraphQL.Query
{
    public class BlogArticleQuery
    {
        private const int PageSize = 25;
        private const int Page = 1;

        public async Task<ResponseWrapper<IReadOnlyList<BlogArticleDto>>> GetAllBlogArticles([Service] IBlogArticleService blogArticleService, [Service] ITopicEventSender eventSender, int? page, int? pageSize)
        {
            var articles = blogArticleService.GetAllPaginated(page ?? Page, pageSize ?? PageSize);
            await eventSender.SendAsync("ReturnedBlogArticles", articles);
            return new ResponseWrapper<IReadOnlyList<BlogArticleDto>>(articles.Item1, articles.Item2);
        }

        public async Task<BlogArticleDto> GetBlogArticleById([Service] IBlogArticleService blogArticleService, [Service] ITopicEventSender eventSender, Guid id)
        {
            var article = blogArticleService.GetById(id);
            await eventSender.SendAsync("ReturnedBlogArticle", article);
            return article;
        }

        #region Blog Article Comments

        public async Task<IReadOnlyList<BlogArticleCommentDto>> GetAllBlogArticleComments([Service] IBlogArticleCommentService blogArticleCommentService, [Service] ITopicEventSender eventSender, Guid articleId)
        {
            var comments = blogArticleCommentService.GetAll(articleId);
            await eventSender.SendAsync("ReturnedBlogArticleComments", comments);
            return comments;
        }

        #endregion
    }
}
