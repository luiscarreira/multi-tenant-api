﻿using Article.Api.Domain.Models;

namespace Article.Api.GraphQL
{
    public class BlogArticleCommentType : ObjectType<BlogArticleComment>
    {
        protected override void Configure(IObjectTypeDescriptor<BlogArticleComment> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Content).Type<StringType>();
            descriptor.Field(a => a.Author).Type<StringType>();
            descriptor.Field(a => a.Created).Type<DateTimeType>();
            descriptor.Field<BlogArticleResolver>(b => b.GetBlogArticle(default));
        }
    }
}
