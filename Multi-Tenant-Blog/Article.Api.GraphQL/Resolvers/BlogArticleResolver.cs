using Article.Api.Domain.Models;
using Article.Api.Domain.Repositories;

namespace Article.Api.GraphQL.Resolvers
{
    public class BlogArticleResolver
    {
        private readonly IArticleRepository _blogArticleRepository;

        public BlogArticleResolver([Service] IArticleRepository blogArticleRepository)
        {
            _blogArticleRepository = blogArticleRepository;
        }

        public BlogArticle GetBlogArticle([Parent] BlogArticleComment articleComment)
        {
            return _blogArticleRepository.Get(articleComment.BlogArticleId);
        }
    }
}
