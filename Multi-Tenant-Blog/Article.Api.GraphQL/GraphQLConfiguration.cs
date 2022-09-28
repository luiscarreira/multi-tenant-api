using Article.Api.GraphQL.Mutations;
using Article.Api.GraphQL.Query;
using Article.Api.GraphQL.Subscriptions;
using Article.Api.GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Article.Api.GraphQL
{
    public static class GraphQLConfiguration
    {
        public static void ConfigureGraphQL(IServiceCollection services)
        {
            services.AddInMemorySubscriptions().AddGraphQLServer().AddType<BlogArticleType>()
            .AddType<BlogArticleCommentType>()
            .AddQueryType<BlogArticleQuery>()
            .AddMutationType<BlogArticleMutation>()
            .AddSubscriptionType<BlogArticleSubscription>();
        }
    }
}
