using Library.Http.Filters;

namespace Library.Http;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<PaginationHeadersFilter>();
        return services;
    }
}
