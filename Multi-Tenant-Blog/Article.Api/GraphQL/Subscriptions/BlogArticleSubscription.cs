using Article.Api.Domain.Models;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace Article.Api.GraphQL.Subscriptions
{
    public class BlogArticleSubscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<BlogArticle>> OnAuthorCreated([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, BlogArticle>("BlogArticleCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<BlogArticle>>> OnAuthorsGet([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, List<BlogArticle>>("ReturnedBlogArticle", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<BlogArticle>> OnAuthorGet([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, BlogArticle>("ReturnedBlogArticle", cancellationToken);
        }

        //[SubscribeAndResolve]
        //public async ValueTask<ISourceStream<BlogPost>>
        //OnBlogPostsGet([Service] ITopicEventReceiver
        //eventReceiver, CancellationToken cancellationToken)
        //{
        //    return await eventReceiver.SubscribeAsync<string,
        //    BlogPost>("ReturnedBlogPosts", cancellationToken);
        //}
        //[SubscribeAndResolve]
        //public async ValueTask<ISourceStream<BlogPost>>
        //OnBlogPostGet([Service] ITopicEventReceiver
        //eventReceiver, CancellationToken cancellationToken)
        //{
        //    return await eventReceiver.SubscribeAsync<string,
        //    BlogPost>("ReturnedBlogPost", cancellationToken);
        //}
    }
}
