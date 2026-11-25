using System.Collections;
using Library.Application.Common.Interfaces;

namespace Library.Application.Common.Models;

public record class PagedResult<T>(
    IReadOnlyCollection<T> Items,
    int TotalCount,
    int TotalPages,
    int Page,
    int PageSize
) : IPagedResult
{
    IEnumerable IPagedResult.Items => Items;

    public PagedResult<TResult> Map<TResult>(Func<T, TResult> selector)
    {
        return new PagedResult<TResult>(
            [.. Items.Select(selector)],
            TotalCount,
            TotalPages,
            Page,
            PageSize
        );
    }
};
