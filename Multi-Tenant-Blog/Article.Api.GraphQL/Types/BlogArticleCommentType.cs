﻿using Article.Api.Business.DataTransferObjects;
using Article.Api.Domain.Models;
using Article.Api.GraphQL.Resolvers;

namespace Article.Api.GraphQL.Types
{
    public class BlogArticleCommentType : ObjectType<BlogArticleCommentDto>
    {
        protected override void Configure(IObjectTypeDescriptor<BlogArticleCommentDto> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Content).Type<StringType>();
            descriptor.Field(a => a.Author).Type<StringType>();
            descriptor.Field(a => a.Created).Type<DateTimeType>();
            descriptor.Field<BlogArticleResolver>(b => b.GetBlogArticle(default, default));
        }
    }
}