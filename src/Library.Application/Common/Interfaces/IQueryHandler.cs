namespace Library.Application.Common.Interfaces;

public interface IQueryHandler<in TQuery, TDto>
{
    Task<TDto> Handle(TQuery query, CancellationToken cancellationToken);
}
