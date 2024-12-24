using CleanArchitecture.Application.RepositoryInterfaces.Common;
using CleanArchitecture.Domain.Entities.Users;

namespace CleanArchitecture.Application.RepositoryInterfaces.Users;

public interface IUserRepository : IGenericRepository<User>
{
}
