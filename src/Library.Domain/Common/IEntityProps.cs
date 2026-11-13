namespace Library.Domain.Common;

public interface IEntityProps;

public interface IEntityReconstitutionProps : IEntityProps
{
    Guid Id { get; init; }
}
