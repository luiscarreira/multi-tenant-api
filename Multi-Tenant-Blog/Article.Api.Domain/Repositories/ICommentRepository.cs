using Article.Api.Domain.Models;
using Domain.Common.Contracts;

namespace Article.Api.Domain.Repositories
{
    public interface ICommentRepository : IBaseRepository<BlogArticleComment>
    {
    }
}
