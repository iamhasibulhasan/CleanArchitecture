using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Features.Users.Command.Dtos;

namespace CleanArchitecture.Application.ServiceInterfaces.Users;

public interface IUserService
{
    Task<Result> Create(CreateUserDto model, CancellationToken cancellationToken, bool savechanges = true);
    //Task<Result> UpdateStudent(UpdateUserDto model, CancellationToken cancellationToken, bool savechanges = true);
    //Task<Result> DeleteStudent(int id, CancellationToken cancellationToken, bool savechanges = true);

    //Task<Result> GetAll(CancellationToken cancellationToken);
    //Task<Result> GetById(int id, CancellationToken cancellationToken);
}
