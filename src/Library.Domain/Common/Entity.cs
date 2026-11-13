namespace Library.Domain.Common;

public abstract class Entity(IEntityProps props)
{
    public Guid Id { get; } =
        props is IEntityReconstitutionProps reconstitution ? reconstitution.Id : Guid.NewGuid();
}
