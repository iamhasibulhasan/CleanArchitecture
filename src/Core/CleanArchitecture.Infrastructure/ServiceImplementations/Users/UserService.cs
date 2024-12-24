using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Features.Users.Command.Dtos;
using CleanArchitecture.Application.RepositoryInterfaces.Users;
using CleanArchitecture.Application.ServiceInterfaces.Users;
using CleanArchitecture.Domain.Entities.Users;

namespace CleanArchitecture.Infrastructure.ServiceImplementations.Users
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Create(CreateUserDto model, CancellationToken cancellationToken, bool savechanges = true)
        {
            User student = User.Create(model.UserCode, model.FirstName, model.LastName, model.DateOfBirth, model.Email, model.Phone);
            await _userRepository.CreateAsync(student, savechanges, cancellationToken);

            return Utility.GetSuccessMsg(CommonMessages.SavedSuccessfully);
        }
    }
}
