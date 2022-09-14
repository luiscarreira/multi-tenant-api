using Article.Api.Domain.Models;
using Article.Api.Domain.Repositories;
using Article.Api.Infrastructure.EFCore.Context;
using Infrastructure.EFCore.Common.Context.Contracts;
using Infrastructure.EFCore.Common.Repositories;

namespace Article.Api.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository : EFCoreBaseRepository<BlogArticle>, IArticleRepository
    {
        public ArticleRepository(IContextFactory<BlogArticleContext> contextFactory) : base(contextFactory.DbContext)
        {
        }
    }
}
