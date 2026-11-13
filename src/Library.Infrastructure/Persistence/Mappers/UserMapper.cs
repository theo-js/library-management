using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Entities;

namespace Library.Infrastructure.Persistence.Mappers;

public static class UserMapper
{
    public static User ToDomain(this UserEntity userEntity) =>
        User.Reconstitute(new() { Id = userEntity.Id, EmailAddress = userEntity.EmailAddress });

    public static UserEntity ToPersistence(this User user) => new() { Id = user.Id };
}
