using Article.Api.Business.Contracts.OData;
using Article.Api.Domain.Models;
using Article.Api.Domain.Repositories;
using Business.Common.Contracts;

namespace Article.Api.Business.Services.OData
{
    public class BlogArticleODataService : BlogArticleService, IBlogArticleODataService
    {
        public BlogArticleODataService(IArticleRepository articleRepository, IUnitOfWork unitOfWork) 
            : base(articleRepository, unitOfWork)
        {
        }

        public IQueryable<BlogArticle> GetAllQueryable()
        {
            return articleRepository.GetAll();
        }
    }
}
