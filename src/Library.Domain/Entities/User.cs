using Library.Domain.Common;
using Library.Domain.ValueObjects;

namespace Library.Domain.Entities;

public class User : Entity, IEntity<User, UserProps, UserReconstitutionProps>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public EmailAddress EmailAddress { get; set; }

    private User(UserProps props)
        : base(props)
    {
        EmailAddress = new(props.EmailAddress);
    }

    public static User Create(UserProps props) => new(props);

    public static User Reconstitute(UserReconstitutionProps props) => new(props);
}

public record class UserProps : IEntityProps
{
    public required string EmailAddress { get; set; }
}

public record class UserReconstitutionProps : UserProps, IEntityReconstitutionProps
{
    public required Guid Id { get; init; }
}
