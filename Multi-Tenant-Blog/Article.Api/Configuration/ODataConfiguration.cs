using Article.Api.Domain.Models;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Article.Api.Configuration
{
    public static class ODataConfiguration
    {
        //public static void ConfigureService(IServiceCollection services)
        //{
        //    services.AddControllers().AddOData(options => options.AddRouteComponents("v1", GetEdmModel()).Select().Filter().OrderBy().Expand());
        //}

        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
            builder.EntitySet<BlogArticle>("BlogArticleOData");
            return builder.GetEdmModel();
        }
    }
}
