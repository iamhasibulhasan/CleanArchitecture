using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Features.Education.Command.Dtos;
using CleanArchitecture.Application.RepositoryInterfaces.Common;
using CleanArchitecture.Application.RepositoryInterfaces.Users;
using CleanArchitecture.Application.ServiceInterfaces.Users;
using CleanArchitecture.Domain.Entities.Users;

namespace CleanArchitecture.Infrastructure.ServiceImplementations.Users;

public sealed class EducationService : IEducationService
{
    private readonly IEducationRepository _educationRepository;
    private readonly IDapperRepository _dapperRepository;
    private readonly IUserRepository _userRepository;

    public EducationService(IEducationRepository educationRepository,
                            IDapperRepository dapperRepository,
                            IUserRepository userRepository)
    {
        _educationRepository = educationRepository;
        _dapperRepository = dapperRepository;
        _userRepository = userRepository;
    }

    #region Command
    public async Task<Result> Create(CreateEducationDto model, CancellationToken cancellationToken, bool savechanges = true)
    {
        var user = await _userRepository.GetByIdAsync(model.UserId, cancellationToken);
        if (user is null)
        {
            return Utility.GetNoDataFoundMsg();
        }


        Education education = Education.Create(user, model.Degree, model.FieldOfStudy, model.InstitutionName, model.StartDate, model.EndDate, model.Grade, model.Description);

        await _educationRepository.CreateAsync(education, savechanges, cancellationToken);

        return Utility.GetSuccessMsg(CommonMessages.SavedSuccessfully);
    }

    public async Task<Result> Update(UpdateEducationDto model, CancellationToken cancellationToken, bool savechanges = true)
    {
        var exists = await _educationRepository.GetByIdAsync(model.Id, cancellationToken);
        if (exists is null)
        {
            return Utility.GetNoDataFoundMsg(CommonMessages.NoDataFound);
        }
        exists.Update(model.Degree, model.FieldOfStudy, model.InstitutionName, model.StartDate, model.EndDate, model.Grade, model.Description);
        await _educationRepository.UpdateAsync(exists, savechanges, cancellationToken);
        return Utility.GetSuccessMsg(CommonMessages.UpdatedSuccessfully);
    }

    public async Task<Result> Delete(int id, CancellationToken cancellationToken, bool savechanges = true)
    {
        var exists = await _educationRepository.GetByIdAsync(id, cancellationToken);
        if (exists is null)
        {
            return Utility.GetNoDataFoundMsg(CommonMessages.NoDataFound);
        }
        await _educationRepository.DeleteAsync(id, savechanges, cancellationToken);
        return Utility.GetSuccessMsg(CommonMessages.DeletedSuccessfully);
    }
    #endregion

    #region Queries

    public async Task<Result> GetAll(CancellationToken cancellationToken)
    {
        var res = await _educationRepository.GetAllAsync(cancellationToken);

        //DynamicParameters dynamicParameters = new();
        //var query = $"SELECT * FROM {StoredProcedureNames.users_getall}()";
        //var res = await _dapperRepository.GetAllAsync<GetAllUserDto>(query, dynamicParameters);

        if (res.Count <= 0)
            return Utility.GetNoDataFoundMsg();

        return Utility.GetSuccessMsg(CommonMessages.DataExists, res);
    }

    public async Task<Result> GetById(int id, CancellationToken cancellationToken)
    {
        var res = await _educationRepository.GetByIdAsync(id, cancellationToken);

        //DynamicParameters dynamicParameters = new();
        //var query = $"SELECT * FROM {StoredProcedureNames.users_getbyid}({id})";
        //var res = await _dapperRepository.GetBySingleParamAsync<GetByIdUserDto>(query, dynamicParameters);

        if (res is null)
            return Utility.GetNoDataFoundMsg();

        return Utility.GetSuccessMsg(CommonMessages.DataExists, res);
    }
    #endregion


}
