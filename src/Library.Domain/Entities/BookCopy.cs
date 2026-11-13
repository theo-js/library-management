using Library.Domain.Common;

namespace Library.Domain.Entities;

public class BookCopy(BookCopyProps props)
    : Entity(props),
        IEntity<BookCopy, BookCopyProps, BookCopyReconstitutionProps>
{
    public static BookCopy Create(BookCopyProps props) => new(props);

    public static BookCopy Reconstitute(BookCopyReconstitutionProps props) => new(props);
}

public record class BookCopyProps : IEntityProps { }

public record class BookCopyReconstitutionProps : BookCopyProps, IEntityReconstitutionProps
{
    public required Guid Id { get; init; }
}
