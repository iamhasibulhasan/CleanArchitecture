using CleanArchitecture.Application.RepositoryInterfaces.Users;
using CleanArchitecture.Domain.Entities.Users;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.RepositoryImplementations.Common;

namespace CleanArchitecture.Infrastructure.RepositoryImplementations.Users;

public sealed class EducationRepository : GenericRepository<Education>, IEducationRepository
{
    private readonly DefaultDbContext _context;
    public EducationRepository(DefaultDbContext context) : base(context)
    {
        _context = context;
    }
}
