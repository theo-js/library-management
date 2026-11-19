using FluentValidation;
using Library.Application.Features.Books.Commands.AddBook;
using Library.Application.Features.Books.Commands.DeleteBook;
using Library.Application.Features.Books.Queries.GetBookById;
using Library.Application.Features.Books.Queries.SearchBooks;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddScoped<SearchBooksQueryHandler>();
        services.AddScoped<GetBookByIdQueryHandler>();
        services.AddScoped<AddBookCommandHandler>();
        services.AddScoped<DeleteBookCommandHandler>();
        return services;
    }
}
