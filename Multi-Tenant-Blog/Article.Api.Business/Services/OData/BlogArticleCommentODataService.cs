using Article.Api.Business.Contracts.OData;
using Article.Api.Domain.Models;
using Article.Api.Domain.Repositories;
using Business.Common.Contracts;

namespace Article.Api.Business.Services.OData
{
    public class BlogArticleCommentODataService : BlogArticleCommentService, IBlogArticleCommentODataService
    {
        public BlogArticleCommentODataService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
            : base(commentRepository, unitOfWork)
        {

        }

        public IQueryable<BlogArticleComment> GetAllQueryable(Guid articleId)
        {
            return commentRepository.FindBy(x => x.BlogArticleId == articleId);
        }
    }
}
