using Library.Application.Common.Interfaces;
using Library.Http.Common.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library.Http.Filters;

public class PaginationHeadersFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(
        ResultExecutingContext context,
        ResultExecutionDelegate next
    )
    {
        if (context.Result is ObjectResult { Value: IPagedResult pagedResult } objectResult)
        {
            var headers = context.HttpContext.Response.Headers;

            headers[PaginationHeaders.TotalCount] = pagedResult.TotalCount.ToString();
            headers[PaginationHeaders.TotalPages] = pagedResult.TotalPages.ToString();
            headers[PaginationHeaders.Page] = pagedResult.Page.ToString();
            headers[PaginationHeaders.PageSize] = pagedResult.PageSize.ToString();

            context.Result = new ObjectResult(pagedResult.Items)
            {
                StatusCode = objectResult.StatusCode,
            };
        }

        await next();
    }
}
