using Article.Api.Business.Contracts;
using Article.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Article.Api.Controllers
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

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<ArticleController>
        [HttpPost]
        public void Post([FromBody] BlogArticle value)
        {
            articleService.CreateArticle(value.Title, value.Content, value.Author);
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
