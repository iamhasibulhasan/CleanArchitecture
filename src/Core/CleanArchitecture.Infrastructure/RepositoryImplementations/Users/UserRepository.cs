using CleanArchitecture.Application.RepositoryInterfaces.Users;
using CleanArchitecture.Domain.Entities.Users;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.RepositoryImplementations.Common;

namespace CleanArchitecture.Infrastructure.RepositoryImplementations.Users
{
    public sealed class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DefaultDbContext _context;

        public UserRepository(DefaultDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
