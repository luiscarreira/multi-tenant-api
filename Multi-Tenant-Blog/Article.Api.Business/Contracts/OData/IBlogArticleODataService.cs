using Article.Api.Domain.Models;

namespace Article.Api.Business.Contracts.OData
{
    public interface IBlogArticleODataService : IBlogArticleService
    {
        public IQueryable<BlogArticle> GetAllQueryable();
    }
}
