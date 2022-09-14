using Article.Api.Infrastructure.EFCore.Context;
using Infrastructure.EFCore.Common.Context.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Article.Api.Configuration
{
    public static class EntityFrameworkConfiguration
    {
        public static void ConfigureDefaultEFCoreContext(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<BlogArticleContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
