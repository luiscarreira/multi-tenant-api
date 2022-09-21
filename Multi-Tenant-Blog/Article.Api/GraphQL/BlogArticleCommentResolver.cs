using Article.Api.Domain.Models;
using Article.Api.Domain.Repositories;
using HotChocolate.Resolvers;

namespace Article.Api.GraphQL
{
    public class BlogArticleCommentResolver
    {
        private readonly ICommentRepository _blogArticleCommentRepository;

        public BlogArticleCommentResolver([Service] ICommentRepository blogArticleCommentRepository)
        {
            _blogArticleCommentRepository = blogArticleCommentRepository;
        }

        public IEnumerable<BlogArticleComment> GetBlogArticleComments([Parent] BlogArticle article)
        {
            return _blogArticleCommentRepository.GetAll()
            .Where(b => b.BlogArticleId == article.Id);
        }
    }
}
