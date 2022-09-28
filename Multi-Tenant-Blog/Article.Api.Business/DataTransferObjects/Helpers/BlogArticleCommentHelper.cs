using Article.Api.Domain.Models;

namespace Article.Api.Business.DataTransferObjects.Helpers
{
    public static class BlogArticleCommentHelper
    {
        public static BlogArticleCommentDto ToDto(this BlogArticleComment domainEntity)
        {
            return new BlogArticleCommentDto
            {
                Id = domainEntity.Id,
                Content = domainEntity.Content,
                Author = domainEntity.Author,
                Created = domainEntity.Created,
                BlogArticleId = domainEntity.BlogArticleId
            };
        }

        public static IEnumerable<BlogArticleCommentDto> ToDto(this IEnumerable<BlogArticleComment> domainEntities)
        {
            var result = new List<BlogArticleCommentDto>();
            foreach (var domainEntity in domainEntities)
            {
                result.Add(domainEntity.ToDto());
            }
            return result;
        }
    }
}
