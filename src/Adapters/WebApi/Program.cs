using Application;
using Infrastructure.Postgres;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using WebApi.Transformers;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseDefaultServiceProvider((context, provider) =>
    {
        provider.ValidateScopes = 
            provider.ValidateOnBuild =
                context.HostingEnvironment.IsDevelopment();
    })
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) =>
    {

        services.AddRouting(options => options.LowercaseUrls = false);

        builder.Services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(new SlugParametersTransformer()));
            options.SuppressAsyncSuffixInActionNames = true;
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        services
            .AddPostgresLayer(context.Configuration)
            .AddApplicationLayer();
    });

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
