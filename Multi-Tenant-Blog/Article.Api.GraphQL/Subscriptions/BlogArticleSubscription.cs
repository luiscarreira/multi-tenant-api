using Article.Api.Business.DataTransferObjects;
using Article.Api.Domain.Models;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace Article.Api.GraphQL.Subscriptions
{
    public class BlogArticleSubscription
    {
        ITopicEventReceiver eventReceiver;

        public BlogArticleSubscription(ITopicEventReceiver eventReceiver)
        {
            this.eventReceiver = eventReceiver;
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<BlogArticleDto>> OnBlogArticleCreated(CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, BlogArticleDto>("BlogArticleCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<BlogArticleDto>>> OnBlogArticlesGet(CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, List<BlogArticleDto>>("ReturnedBlogArticle", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<BlogArticleDto>> OnBlogArticleGet(CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, BlogArticleDto>("ReturnedBlogArticle", cancellationToken);
        }

        #region Blog Article Comment

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<BlogArticleCommentDto>> OnBlogArticleCommentCreated(CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, BlogArticleCommentDto>("BlogArticleCommentCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<BlogArticleDto>>> OnBlogArticleCommentsGet(CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, List<BlogArticleDto>>("ReturnedBlogArticleComments", cancellationToken);
        }

        

        #endregion
    }
}
