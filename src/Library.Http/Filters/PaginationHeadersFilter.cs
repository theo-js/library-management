using Library.Application.Common.Interfaces;
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

            headers["X-Total-Count"] = pagedResult.TotalCount.ToString();
            headers["X-Total-Pages"] = pagedResult.TotalPages.ToString();
            headers["X-Current-Page"] = pagedResult.Page.ToString();
            headers["X-Page-Size"] = pagedResult.PageSize.ToString();

            context.Result = new ObjectResult(pagedResult.Items)
            {
                StatusCode = objectResult.StatusCode,
            };
        }

        await next();
    }
}
