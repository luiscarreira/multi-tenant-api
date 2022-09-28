using Article.Api.Domain.Models;

namespace Article.Api.Business.DataTransferObjects.Helpers
{
    public static class BlogArticleHelper
    {
        public static BlogArticleDto ToDto(this BlogArticle domainEntity)
        {
            return new BlogArticleDto
            {
                Id = domainEntity.Id,
                Title = domainEntity.Title,
                Content = domainEntity.Content,
                Author = domainEntity.Author,
                CreatedDate = domainEntity.CreatedDate,
                UpdatedDate = domainEntity.UpdatedDate
            };
        }

        public static IEnumerable<BlogArticleDto> ToDto(this IEnumerable<BlogArticle> domainEntities)
        {
            var result = new List<BlogArticleDto>();
            foreach (var domainEntity in domainEntities)
            {
                result.Add(domainEntity.ToDto());
            }
            return result;
        }
    }
}
