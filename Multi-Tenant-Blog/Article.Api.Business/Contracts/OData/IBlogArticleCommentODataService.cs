using Article.Api.Domain.Models;

namespace Article.Api.Business.Contracts.OData
{
    public interface IBlogArticleCommentODataService : IBlogArticleCommentService
    {
        public IQueryable<BlogArticleComment> GetAllQueryable(Guid articleId);
    }
}
