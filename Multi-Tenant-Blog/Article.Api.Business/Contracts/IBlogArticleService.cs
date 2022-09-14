using Article.Api.Domain.Models;

namespace Article.Api.Business.Contracts
{
    public interface IBlogArticleService
    {
        public IReadOnlyList<BlogArticle> GetAllPaginated(int page, int pageSize);

        public BlogArticle CreateArticle(string title, string content, string author);
    }
}
