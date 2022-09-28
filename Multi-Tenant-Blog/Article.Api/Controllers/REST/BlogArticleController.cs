using Article.Api.Business.Contracts;
using Article.Api.Business.DataTransferObjects;
using Article.Api.Domain.Models;
using Article.Api.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Article.Api.Controllers.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogArticleController : ControllerBase
    {
        private const int PageSize = 25;
        private const int Page = 1;

        private IBlogArticleService articleService;
        private IBlogArticleCommentService commentService;

        public BlogArticleController(IBlogArticleService articleService, IBlogArticleCommentService commentService)
        {
            this.articleService = articleService;
            this.commentService = commentService;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public IEnumerable<BlogArticleDto> Get([FromQuery] int pageSize = PageSize, [FromQuery] int pageNumber = Page)
        {
            return articleService.GetAllPaginated(pageNumber, pageSize).Item1;
        }

        // GET api/<ArticleController>/00000000-0000-0000-0000-000000000000
        [HttpGet("{id}")]
        public BlogArticleDto Get(Guid id)
        {
            return articleService.GetById(id);
        }

        // POST api/<ArticleController>
        [HttpPost]
        public void Post([FromBody] BlogArticle value)
        {
            articleService.CreateArticle(value.Title, value.Content, value.Author);
        }

        // PUT api/<ArticleController>/00000000-0000-0000-0000-000000000000
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] BlogArticle value)
        {
            articleService.UpdateArticle(id, value.Title, value.Content, value.Author);
        }

        // DELETE api/<ArticleController>/00000000-0000-0000-0000-000000000000
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            articleService.DeleteArticle(id);
        }

        #region Comments

        // GET api/<ArticleController>/00000000-0000-0000-0000-000000000000/comment
        [HttpGet("{id}/comment")]
        public IEnumerable<BlogArticleCommentDto> GetComments(Guid id, [FromQuery] int pageSize = PageSize, [FromQuery] int pageNumber = Page)
        {
            return commentService.GetAllPaginated(id, pageNumber, pageSize);
        }

        // GET api/<ArticleController>/00000000-0000-0000-0000-000000000000/comment/00000000-0000-0000-0000-000000000000
        [HttpGet("{id}/comment/{commentId}")]
        public BlogArticleCommentDto GetComment(Guid commentId)
        {
            return commentService.GetById(commentId);
        }

        // POST api/<ArticleController>/00000000-0000-0000-0000-000000000000/comment
        [HttpPost("{id}/comment")]
        public void Post(Guid id, [FromBody] BlogArticleComment value)
        {
            commentService.CreateArticleComment(id, value.Content, value.Author);
        }

        // DELETE api/<ArticleController>/00000000-0000-0000-0000-000000000000/comment/00000000-0000-0000-0000-000000000000
        [HttpDelete("{id}/comment/{commentId}")]
        public void Delete(Guid id, Guid commentId)
        {
            commentService.DeleteArticleComment(id, commentId);
        }

        #endregion
    }
}
