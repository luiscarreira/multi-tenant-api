using Article.Api.Business.Contracts;
using Article.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Article.Api.Controllers.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogArticleController : ControllerBase
    {
        private IBlogArticleService articleService;

        public BlogArticleController(IBlogArticleService articleService)
        {
            this.articleService = articleService;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public IEnumerable<BlogArticle> Get()
        {
            var articles = articleService.GetAllPaginated(1, 50);
            return articles;
        }

        // GET api/<ArticleController>/00000000-0000-0000-0000-000000000000
        [HttpGet("{id}")]
        public BlogArticle Get(Guid id)
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
    }
}
