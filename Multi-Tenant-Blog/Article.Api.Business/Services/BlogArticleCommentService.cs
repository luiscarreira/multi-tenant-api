using Article.Api.Business.Contracts;
using Article.Api.Business.DataTransferObjects;
using Article.Api.Business.DataTransferObjects.Helpers;
using Article.Api.Domain.Models;
using Article.Api.Domain.Repositories;
using Business.Common.Contracts;

namespace Article.Api.Business.Services
{
    public class BlogArticleCommentService : IBlogArticleCommentService
    {
        protected ICommentRepository commentRepository;
        protected IUnitOfWork unitOfWork;

        public BlogArticleCommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            this.commentRepository = commentRepository;
            this.unitOfWork = unitOfWork;
        }

        public BlogArticleCommentDto CreateArticleComment(Guid articleId, string content, string author)
        {
            var comment = new BlogArticleComment(articleId, author, content);
            comment = commentRepository.Add(comment);
            unitOfWork.Commit();
            return comment.ToDto();
        }

        public void DeleteArticleComment(Guid articleId, Guid id)
        {
            var comment = commentRepository.Get(id);

            if (comment.BlogArticleId == articleId)
            {
                commentRepository.Delete(comment);
                unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("The comment does not belong to the article");
            }
        }

        public IReadOnlyList<BlogArticleCommentDto> GetAll(Guid articleId)
        {
            return commentRepository.FindBy(x => x.BlogArticleId == articleId).ToDto().ToList();
        }

        public IReadOnlyList<BlogArticleCommentDto> GetAllPaginated(Guid articleId, int page, int pageSize)
        {
            return commentRepository.FindBy(x => x.BlogArticleId == articleId).Skip(page * pageSize).Take(pageSize).ToDto().ToList();  
        }

        public BlogArticleCommentDto GetById(Guid id)
        {
            return commentRepository.Get(id).ToDto();
        }
    }
}
