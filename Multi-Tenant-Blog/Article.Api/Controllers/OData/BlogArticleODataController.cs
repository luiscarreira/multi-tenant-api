using Article.Api.Business.Contracts;
using Article.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Article.Api.Controllers.OData
{
    public class BlogArticleODataController : ODataController
    {
        private IBlogArticleService articleService;

        public BlogArticleODataController(IBlogArticleService articleService)
        {
            this.articleService = articleService;
        }

        [EnableQuery(PageSize = 15)]
        public IQueryable<BlogArticle> Get()
        {
            var articles = articleService.GetAllQueryable();
            return articles;
        }
    }
}
