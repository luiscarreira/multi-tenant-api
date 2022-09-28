using Article.Api.Domain.Models;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Article.Api.Configuration
{
    public static class ODataConfiguration
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
            builder.EntitySet<BlogArticle>("BlogArticleOData");
            builder.EntitySet<BlogArticleComment>("BlogArticleCommentOData");
            return builder.GetEdmModel();
        }
    }
}
