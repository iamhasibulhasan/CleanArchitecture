using CleanArchitecture.Application.Abstraction.MediatR;
using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.ServiceInterfaces.Users;

namespace CleanArchitecture.Application.Features.Users.Command.Delete;

public sealed record DeleteUserCommand(int id) : ICommand;
public sealed class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
{
    private readonly IUserService _userService;
    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await _userService.Delete(request.id, cancellationToken);
    }
}
