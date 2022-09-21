using Article.Api.Configuration;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.OData;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Article.Api.GraphQL;
using Article.Api.GraphQL.Query;
using Article.Api.GraphQL.Subscriptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy().Expand().SkipToken().SetMaxTop(null).AddRouteComponents("odata", ODataConfiguration.GetEdmModel()));
builder.Services.AddInMemorySubscriptions().AddGraphQLServer().AddType<BlogArticleType>()
            .AddType<BlogArticleCommentType>()
            .AddQueryType<BlogArticleQuery>()
            .AddSubscriptionType<BlogArticleSubscription>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IocContainerConfiguration.ConfigureService(builder.Services, builder.Configuration, builder.Environment);
//ODataConfiguration.ConfigureService(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UsePlayground(new PlaygroundOptions
    {
        QueryPath = "/graphql",
        Path = "/playground"
    });
}

app.UseWebSockets();
app.UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();