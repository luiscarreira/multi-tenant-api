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

        public IReadOnlyList<BlogArticle> GetAll()
        {
            return articleRepository.GetAll().ToList();
        }

        public IQueryable<BlogArticle> GetAllQueryable()
        {
            return articleRepository.GetAll();
        }

        public IReadOnlyList<BlogArticle> GetAllPaginated(int page, int pageSize)
        {
            return articleRepository.GetAll(page, pageSize).ToList();
        }

        public BlogArticle GetById(Guid id)
        {
            return articleRepository.Get(id);
        }

        public BlogArticle CreateArticle(string title, string content, string author)
        {
            var article = new BlogArticle(title, content, author);
            article = articleRepository.Add(article);
            unitOfWork.Commit();

            return article;
        }
        
        public BlogArticle UpdateArticle(Guid id, string title, string content, string author)
        {
            var article = articleRepository.Get(id);

            article.Title = title;
            article.Author = author;
            article.Content = content;
            article.UpdatedDate = DateTimeOffset.UtcNow;

            var updatedArticle = articleRepository.Update(article);
            unitOfWork.Commit();

            return updatedArticle;
        }

        public void DeleteArticle(Guid id)
        {
            var article = articleRepository.Get(id);
            articleRepository.Delete(article);
            unitOfWork.Commit();
        }
    }
}
