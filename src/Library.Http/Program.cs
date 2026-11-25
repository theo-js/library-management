using Library.Application;
using Library.Http;
using Library.Http.Common.Headers;
using Library.Http.Filters;
using Library.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddOpenApi()
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddApiServices()
    .AddCors(options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.WithExposedHeaders(PaginationHeaders.All);
            });
        }
    })
    .AddControllers(options =>
    {
        options.Filters.AddService<PaginationHeadersFilter>();
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.UseCors();

app.UseHttpsRedirection();

app.Run();
