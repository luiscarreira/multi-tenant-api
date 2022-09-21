using Article.Api.Domain.Models;
using Article.Api.Domain.Repositories;
using HotChocolate.Subscriptions;

namespace Article.Api.GraphQL.Query
{
    public class BlogArticleQuery
    {
        public async Task<List<BlogArticle>> GetAllBlogArticles([Service] IArticleRepository blogArticleRepository, [Service] ITopicEventSender eventSender)
        {
            List<BlogArticle> articles = blogArticleRepository.GetAll().ToList();
            await eventSender.SendAsync("ReturnedBlogArticles", articles);
            return articles;
        }

        public async Task<BlogArticle> GetBlogArticleById([Service] IArticleRepository blogArticleRepository, [Service] ITopicEventSender eventSender, Guid id)
        {
            BlogArticle article = blogArticleRepository.Get(id);
            await eventSender.SendAsync("ReturnedBlogArticle", article);
            return article;
        }

        //public async Task<List<BlogPost>>
        //GetAllBlogPosts([Service] IBlogPostRepository
        //blogPostRepository,
        //[Service] ITopicEventSender eventSender)
        //{
        //    List<BlogPost> blogPosts =
        //    blogPostRepository.GetBlogPosts();
        //    await eventSender.SendAsync("ReturnedBlogPosts",
        //    blogPosts);
        //    return blogPosts;
        //}
        //public async Task<BlogPost> GetBlogPostById([Service]
        //IBlogPostRepository blogPostRepository,
        //[Service] ITopicEventSender eventSender, int id)
        //{
        //    BlogPost blogPost =
        //    blogPostRepository.GetBlogPostById(id);
        //    await eventSender.SendAsync("ReturnedBlogPost",
        //    blogPost);
        //    return blogPost;
        //}
    }
}
