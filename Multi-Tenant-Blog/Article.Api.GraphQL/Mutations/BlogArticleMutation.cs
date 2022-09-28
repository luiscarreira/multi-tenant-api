using Article.Api.Business.Contracts;
using Article.Api.Business.DataTransferObjects;
using Article.Api.Domain.Models;
using HotChocolate.Subscriptions;

namespace Article.Api.GraphQL.Mutations
{
    public class BlogArticleMutation
    {
        public async Task<BlogArticleDto> CreateBlogArticle([Service] IBlogArticleService blogArticleService, [Service] ITopicEventSender eventSender, BlogArticleDto article)
        {
            var result = blogArticleService.CreateArticle(article.Title, article.Content, article.Author);
            await eventSender.SendAsync("BlogArticleCreated", result);
            return result;
        }

        public async Task<BlogArticleCommentDto> CreateBlogArticleComment([Service] IBlogArticleCommentService blogArticleCommentService, [Service] ITopicEventSender eventSender, Guid articleId, BlogArticleCommentDto comment)
        {
            var result = blogArticleCommentService.CreateArticleComment(articleId, comment.Content, comment.Author);
            await eventSender.SendAsync("BlogArticleCommentCreated", result);
            return result;
        }
    }
}
