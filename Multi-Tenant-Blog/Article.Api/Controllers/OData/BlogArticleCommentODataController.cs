using Article.Api.Business.Contracts.OData;
using Article.Api.Business.DataTransferObjects;
using Article.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Article.Api.Controllers.OData
{
    public class BlogArticleCommentODataController : ODataController
    {
        private IBlogArticleCommentODataService articleCommentODataService;

        public BlogArticleCommentODataController(IBlogArticleCommentODataService articleCommentODataService)
        {
            this.articleCommentODataService = articleCommentODataService;
        }

        [EnableQuery(PageSize = 15)]
        public IQueryable<BlogArticleComment> Get([FromODataUri(Name = "parentKey")] Guid parentKey)
        {
            var articles = articleCommentODataService.GetAllQueryable(parentKey);
            return articles;
        }

        public ActionResult Post([FromODataUri(Name = "parentKey")] Guid parentKey, [FromBody] BlogArticleCommentDto comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            comment = articleCommentODataService.CreateArticleComment(parentKey, comment.Content, comment.Author);
            return Created(comment);
        }

        [HttpDelete]
        public ActionResult Delete([FromODataUri(Name = "parentKey")] Guid parentKey, [FromODataUri(Name = "Key")] Guid key)
        {
            articleCommentODataService.DeleteArticleComment(parentKey, key);
            return NoContent();
        }
    }
}
