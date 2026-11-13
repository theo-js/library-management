using Library.Domain.Common;

namespace Library.Domain.Entities;

public class BookBorrowing(BookBorrowingProps props)
    : Entity(props),
        IEntity<BookBorrowing, BookBorrowingProps, BookBorrowingReconstitutionProps>
{
    public static BookBorrowing Create(BookBorrowingProps props) => new(props);

    public static BookBorrowing Reconstitute(BookBorrowingReconstitutionProps props) => new(props);
}

public record class BookBorrowingProps : IEntityProps { }

public record class BookBorrowingReconstitutionProps
    : BookBorrowingProps,
        IEntityReconstitutionProps
{
    public required Guid Id { get; init; }
}
