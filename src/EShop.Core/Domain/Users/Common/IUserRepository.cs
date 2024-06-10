using EShop.Core.Domain.Users.Models;

namespace EShop.Core.Domain.Users.Common;

public interface IUserRepository
{
    public Task<User> FindAsync(Guid id, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<User>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken);

    public void Add(User user);

    public void Update(User user);

    public void Delete(IReadOnlyCollection<User> user);

    public Task<User> FindByUserNameAsync(string userName, CancellationToken cancellationToken);

    public Task<User> FindByEmailAsync(string email, CancellationToken cancellationToken);

}
