using Library.Application.Common.Models;

namespace Library.Http.Extensions;

public static class HeadersExtensions
{
    public static void AttachPagedResult<T>(
        this IHeaderDictionary headers,
        PagedResult<T> pagedResult
    )
    {
        headers.Append("X-Page", pagedResult.Page.ToString());
        headers.Append("X-Page-Size", pagedResult.PageSize.ToString());
        headers.Append("X-Total-Pages", pagedResult.TotalPages.ToString());
        headers.Append("X-Total-Count", pagedResult.TotalCount.ToString());
    }
}
