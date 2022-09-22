﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Article.Api.Infrastructure.EFCore.Context.DesignTimeFactory
{
    internal class DesignTimeContextFactory : IDesignTimeDbContextFactory<BlogArticleContext>
    {
        public BlogArticleContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogArticleContext>();
            optionsBuilder.UseSqlServer(@"Server=BPINS042\MSSQLSERVER2019;Database=Blog.Article_DT;User=sa;Password=s@PWD246800!");

            return new BlogArticleContext(optionsBuilder.Options);
        }
    }
}
