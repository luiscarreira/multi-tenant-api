using Article.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Article.Api.Infrastructure.EFCore.Context
{
    public class BlogArticleContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogArticleContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public BlogArticleContext(DbContextOptions<BlogArticleContext> options)
            : base(options)
        {
            //this.dataSeeder = dataSeeder;

            Database.Migrate();
        }

        /// <summary>
        /// Get or sets the Articles data model
        /// </summary>
        public DbSet<BlogArticle> BlogArticles { get; set; }

        /// <summary>
        /// Get or sets the Comments data model
        /// </summary>
        public DbSet<BlogArticleComment> Comments { get; set; }

        /// <summary>
        /// Relation between tables.
        /// </summary>
        /// <param name="modelBuilder">Entity framework model builder before creating database</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogArticle>()
                .HasKey(article => new { article.Id });

            modelBuilder.Entity<BlogArticleComment>()
                .HasOne(c => c.BlogArticle)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.BlogArticleId);


            // Call Data seeder
            //this.dataSeeder.SeedData(modelBuilder);
        }
    }
}
