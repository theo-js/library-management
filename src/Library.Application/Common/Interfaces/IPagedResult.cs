using System.Collections;

namespace Library.Application.Common.Interfaces;

public interface IPagedResult
{
    IEnumerable Items { get; }
    int TotalCount { get; }
    int TotalPages { get; }
    int Page { get; }
    int PageSize { get; }
}
