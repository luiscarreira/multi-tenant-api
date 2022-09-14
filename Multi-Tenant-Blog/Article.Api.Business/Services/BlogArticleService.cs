using Article.Api.Business.Contracts;
using Article.Api.Domain.Models;
using Article.Api.Domain.Repositories;
using Business.Common.Contracts;

namespace Article.Api.Business.Services
{
    public class BlogArticleService : IBlogArticleService
    {
        private IArticleRepository articleRepository;
        private IUnitOfWork unitOfWork;

        public BlogArticleService(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.unitOfWork = unitOfWork;
        }

        public BlogArticle CreateArticle(string title, string content, string author)
        {
            var article = new BlogArticle(title, content, author);
            article = articleRepository.Add(article);
            unitOfWork.Commit();

            return article;
        }

        public IReadOnlyList<BlogArticle> GetAllPaginated(int page, int pageSize)
        {
            return articleRepository.GetAll(page, pageSize).ToList();
        }
    }
}
