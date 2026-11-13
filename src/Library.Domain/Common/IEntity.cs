namespace Library.Domain.Common;

public interface IEntity<TEntity, TEntityProps, TReconstitutionProps>
    where TEntity : Entity, IEntity<TEntity, TEntityProps, TReconstitutionProps>
    where TEntityProps : IEntityProps
    where TReconstitutionProps : IEntityReconstitutionProps
{
    static abstract TEntity Create(TEntityProps props);
    static abstract TEntity Reconstitute(TReconstitutionProps props);
}
