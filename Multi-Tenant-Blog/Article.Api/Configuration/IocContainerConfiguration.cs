using Article.Api.Business.Contracts;
using Article.Api.Business.Contracts.OData;
using Article.Api.Business.Services;
using Article.Api.Business.Services.OData;
using Article.Api.Domain.Repositories;
using Article.Api.Infrastructure.EFCore.Context;
using Article.Api.Infrastructure.EFCore.Repositories;
using Business.Common.Contracts;
using Infrastructure.EFCore.Common.Context.Contracts;
using Infrastructure.EFCore.Common.Context.Implementation;
using Infrastructure.EFCore.Common.DatabaseManager;

namespace Article.Api.Configuration
{
    /// <summary>
    /// IOC contaner start-up configuration
    /// </summary>
    public static class IocContainerConfiguration
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient<IBlogArticleService, BlogArticleService>();
            services.AddTransient<IBlogArticleODataService, BlogArticleODataService>();

            services.AddTransient<IBlogArticleCommentService, BlogArticleCommentService>();
            services.AddTransient<IBlogArticleCommentODataService, BlogArticleCommentODataService>();

            services.AddScoped<IContextFactory<BlogArticleContext>>(x =>
            {
                var httpContextAccessor = x.GetRequiredService<IHttpContextAccessor>();
                var configuration = x.GetRequiredService<IConfiguration>();
                var databaseManager = x.GetRequiredService<IDatabaseManager>();
                return new ContextFactory<BlogArticleContext>(httpContextAccessor, configuration, databaseManager, environment.IsDevelopment());
            });

            services.AddScoped<IDatabaseManager, DatabaseManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork<BlogArticleContext>>();
        }
    }
}
