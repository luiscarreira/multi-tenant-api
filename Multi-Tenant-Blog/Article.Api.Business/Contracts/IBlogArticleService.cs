using Article.Api.Business.DataTransferObjects;
using Article.Api.Domain.Models;

namespace Article.Api.Business.Contracts
{
    public interface IBlogArticleService
    {
        public IReadOnlyList<BlogArticleDto> GetAll();

        public (IReadOnlyList<BlogArticleDto>, int) GetAllPaginated(int page, int pageSize);

        public BlogArticleDto GetById(Guid id);

        public BlogArticleDto CreateArticle(string title, string content, string author);

        public BlogArticleDto UpdateArticle(Guid id, string title, string content, string author);

        public void DeleteArticle(Guid id);        
    }
}
