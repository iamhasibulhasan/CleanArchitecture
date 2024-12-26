using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Constants;
using CleanArchitecture.Application.Features.Users.Command.Dtos;
using CleanArchitecture.Application.Features.Users.Queries.Dtos;
using CleanArchitecture.Application.RepositoryInterfaces.Common;
using CleanArchitecture.Application.RepositoryInterfaces.Users;
using CleanArchitecture.Application.ServiceInterfaces.Users;
using CleanArchitecture.Domain.Entities.Users;
using Dapper;

namespace CleanArchitecture.Infrastructure.ServiceImplementations.Users
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDapperRepository _dapperRepository;

        public UserService(IUserRepository userRepository, IDapperRepository dapperRepository)
        {
            _userRepository = userRepository;
            _dapperRepository = dapperRepository;
        }

        #region Command
        public async Task<Result> Create(CreateUserDto model, CancellationToken cancellationToken, bool savechanges = true)
        {
            User student = User.Create(model.UserCode, model.FirstName, model.LastName, model.DateOfBirth, model.Email, model.Phone);
            await _userRepository.CreateAsync(student, savechanges, cancellationToken);

            return Utility.GetSuccessMsg(CommonMessages.SavedSuccessfully);
        }

        public async Task<Result> Update(UpdateUserDto model, CancellationToken cancellationToken, bool savechanges = true)
        {
            var exists = await _userRepository.GetByIdAsync(model.Id, cancellationToken);
            if (exists is null)
            {
                return Utility.GetNoDataFoundMsg(CommonMessages.NoDataFound);
            }
            exists.Update(model.FirstName, model.LastName, model.DateOfBirth, model.Email, model.Phone);
            await _userRepository.UpdateAsync(exists, savechanges, cancellationToken);
            return Utility.GetSuccessMsg(CommonMessages.UpdatedSuccessfully);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellationToken, bool savechanges = true)
        {
            var exists = await _userRepository.GetByIdAsync(id, cancellationToken);
            if (exists is null)
            {
                return Utility.GetNoDataFoundMsg(CommonMessages.NoDataFound);
            }
            await _userRepository.DeleteAsync(id, savechanges, cancellationToken);
            return Utility.GetSuccessMsg(CommonMessages.DeletedSuccessfully);
        }

        #endregion

        #region Queries
        public async Task<Result> GetAll(CancellationToken cancellationToken)
        {
            //var res = await _userRepository.GetAllAsync(cancellationToken);

            DynamicParameters dynamicParameters = new();
            var query = $"SELECT * FROM {StoredProcedureNames.users_getall}()";
            var res = await _dapperRepository.GetAllAsync<GetAllUserDto>(query, dynamicParameters);

            if (res.Count <= 0)
                return Utility.GetNoDataFoundMsg();

            return Utility.GetSuccessMsg(CommonMessages.DataExists, res);
        }

        public async Task<Result> GetById(int id, CancellationToken cancellationToken)
        {
            //var res = await _userRepository.GetByIdAsync(id, cancellationToken);

            DynamicParameters dynamicParameters = new();
            var query = $"SELECT * FROM {StoredProcedureNames.users_getbyid}({id})";
            var res = await _dapperRepository.GetBySingleParamAsync<GetByIdUserDto>(query, dynamicParameters);

            if (res is null)
                return Utility.GetNoDataFoundMsg();

            return Utility.GetSuccessMsg(CommonMessages.DataExists, res);
        }
        #endregion

    }
}
