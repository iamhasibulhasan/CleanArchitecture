using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Features.Users.Command.Dtos;

namespace CleanArchitecture.Application.ServiceInterfaces.Users;

public interface IUserService
{
    #region Command
    Task<Result> Create(CreateUserDto model, CancellationToken cancellationToken, bool savechanges = true);
    Task<Result> Update(UpdateUserDto model, CancellationToken cancellationToken, bool savechanges = true);
    Task<Result> Delete(int id, CancellationToken cancellationToken, bool savechanges = true);

    #endregion

    #region Queries
    Task<Result> GetAll(CancellationToken cancellationToken);
    Task<Result> GetById(int id, CancellationToken cancellationToken);

    #endregion
}
