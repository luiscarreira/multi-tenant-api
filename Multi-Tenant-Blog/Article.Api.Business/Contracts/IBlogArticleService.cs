using Article.Api.Domain.Models;

namespace Article.Api.Business.Contracts
{
    public interface IBlogArticleService
    {
        public IReadOnlyList<BlogArticle> GetAll();

        public IReadOnlyList<BlogArticle> GetAllPaginated(int page, int pageSize);

        public BlogArticle GetById(Guid id);

        public BlogArticle CreateArticle(string title, string content, string author);

        public BlogArticle UpdateArticle(Guid id, string title, string content, string author);

        public void DeleteArticle(Guid id);

        public IQueryable<BlogArticle> GetAllQueryable();
    }
}
