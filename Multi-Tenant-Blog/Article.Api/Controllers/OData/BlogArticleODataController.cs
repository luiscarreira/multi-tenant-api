using Article.Api.Business.Contracts.OData;
using Article.Api.Business.DataTransferObjects;
using Article.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Article.Api.Controllers.OData
{
    public class BlogArticleODataController : ODataController
    {
        private IBlogArticleODataService articleODataService;

        public BlogArticleODataController(IBlogArticleODataService articleODataService)
        {
            this.articleODataService = articleODataService;
        }

        [EnableQuery(PageSize = 15)]
        public IQueryable<BlogArticle> Get()
        {
            var articles = articleODataService.GetAllQueryable();
            return articles;
        }

        public ActionResult Post([FromBody] BlogArticleDto article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            article = articleODataService.CreateArticle(article.Title, article.Content, article.Author);
            return Created(article);
        }

        [HttpPut]
        public ActionResult Put([FromODataUri(Name ="key")] Guid key, [FromBody] BlogArticleDto article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            article = articleODataService.UpdateArticle(key, article.Title, article.Content, article.Author);
            return Updated(article);
        }

        [HttpDelete]
        public ActionResult Delete([FromODataUri] Guid key)
        {
            articleODataService.DeleteArticle(key);
            return NoContent();
        }

        //For comments to work correctly the model should have a navigation property -> its bounded to the domain models structure
        
    }
}
