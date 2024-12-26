using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Features.Education.Command.Dtos;

namespace CleanArchitecture.Application.ServiceInterfaces.Users;

public interface IEducationService
{
    #region Command
    Task<Result> Create(CreateEducationDto model, CancellationToken cancellationToken, bool savechanges = true);
    Task<Result> Update(UpdateEducationDto model, CancellationToken cancellationToken, bool savechanges = true);
    Task<Result> Delete(int id, CancellationToken cancellationToken, bool savechanges = true);

    #endregion

    #region Queries
    Task<Result> GetAll(CancellationToken cancellationToken);
    Task<Result> GetById(int id, CancellationToken cancellationToken);

    #endregion
}
