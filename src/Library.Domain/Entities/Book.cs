using Library.Domain.Common;
using Library.Domain.ValueObjects;

namespace Library.Domain.Entities;

public class Book : Entity, IEntity<Book, BookProps, BookReconstitutionProps>
{
    public string Title { get; private set; }
    public IsbnNumber IsbnNumber { get; }
    public string Author { get; private set; }
    private readonly List<BookCopy> _copies;

    public IReadOnlyCollection<BookCopy> Copies { get; }

    private Book(BookProps props)
        : base(props)
    {
        Title = props.Title;
        IsbnNumber = new(props.IsbnNumber);
        Author = props.Author;
        _copies = props.Copies?.ToList() ?? [];
        Copies = _copies.AsReadOnly();
    }

    public static Book Create(BookProps props) => new(props);

    public static Book Reconstitute(BookReconstitutionProps props) => new(props);
}

public record class BookProps : IEntityProps
{
    public required string Title { get; init; }
    public required string IsbnNumber { get; init; }
    public required string Author { get; init; }
    public List<BookCopy>? Copies { get; init; }
}

public record class BookReconstitutionProps : BookProps, IEntityReconstitutionProps
{
    public Guid Id { get; init; }
}
