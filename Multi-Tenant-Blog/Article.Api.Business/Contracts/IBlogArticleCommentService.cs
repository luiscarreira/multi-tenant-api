using Article.Api.Business.DataTransferObjects;

namespace Article.Api.Business.Contracts
{
    public interface IBlogArticleCommentService
    {
        public IReadOnlyList<BlogArticleCommentDto> GetAll(Guid articleId);

        public IReadOnlyList<BlogArticleCommentDto> GetAllPaginated(Guid articleId, int page, int pageSize);

        public BlogArticleCommentDto GetById(Guid id);

        public BlogArticleCommentDto CreateArticleComment(Guid articleId, string content, string author);

        public void DeleteArticleComment(Guid articleId, Guid id);
    }
}
