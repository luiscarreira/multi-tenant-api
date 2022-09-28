using Article.Api.Business.Contracts;
using Article.Api.Business.DataTransferObjects;
using Article.Api.Business.DataTransferObjects.Helpers;
using Article.Api.Domain.Models;
using Article.Api.Domain.Repositories;
using Business.Common.Contracts;

namespace Article.Api.Business.Services
{
    public class BlogArticleService : IBlogArticleService
    {
        protected IArticleRepository articleRepository;
        protected IUnitOfWork unitOfWork;

        public BlogArticleService(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.unitOfWork = unitOfWork;
        }

        public IReadOnlyList<BlogArticleDto> GetAll()
        {
            return articleRepository.GetAll().ToDto().ToList();
        }

        public (IReadOnlyList<BlogArticleDto>, int) GetAllPaginated(int page, int pageSize)
        {
             return (articleRepository.GetAll(page, pageSize).ToDto().ToList(), articleRepository.GetAll().Count());
        }

        public BlogArticleDto GetById(Guid id)
        {
            return articleRepository.Get(id).ToDto();
        }

        public BlogArticleDto CreateArticle(string title, string content, string author)
        {
            var article = new BlogArticle(title, content, author);
            article = articleRepository.Add(article);
            unitOfWork.Commit();

            return article.ToDto();
        }
        
        public BlogArticleDto UpdateArticle(Guid id, string title, string content, string author)
        {
            var article = articleRepository.Get(id);

            article.Title = title;
            article.Author = author;
            article.Content = content;
            article.UpdatedDate = DateTimeOffset.UtcNow;

            var updatedArticle = articleRepository.Update(article);
            unitOfWork.Commit();

            return updatedArticle.ToDto();
        }

        public void DeleteArticle(Guid id)
        {
            var article = articleRepository.Get(id);
            articleRepository.Delete(article);
            unitOfWork.Commit();
        }
    }
}
