using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Features.Users.Command.Create;
using CleanArchitecture.Application.Features.Users.Command.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Areas.Users;

public class UserController : BaseApiController
{

    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Command

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserDto model, CancellationToken cancellationToken = default)
    {
        var validationResult = new CreateUserDtoValidator().Validate(model);

        if (!validationResult.IsValid)
        {
            Result result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
            return StatusCode(result.StatusCode, result);
        }
        var command = new CreateUserCommand(model);
        var _result = await _mediator.Send(command, cancellationToken);

        return StatusCode(_result.StatusCode, _result);
    }

    //[HttpPut]
    //public async Task<IActionResult> Put([FromBody] UpdateUserDto model, CancellationToken cancellationToken = default)
    //{
    //    var validationResult = new UpdateUserDtoValidator().Validate(model);

    //    if (!validationResult.IsValid)
    //    {
    //        Result result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
    //        return StatusCode(result.StatusCode, result);
    //    }
    //    var command = new UpdateUserCommand(model);
    //    var _result = await _mediator.Send(command, cancellationToken);

    //    return StatusCode(_result.StatusCode, _result);
    //}

    //[HttpDelete]
    //public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
    //{

    //    Result result;
    //    if (id <= 0)
    //    {
    //        result = Utility.GetValidationFailedMsg(CommonMessages.InvalidId);
    //    }
    //    else
    //    {
    //        var command = new DeleteUserCommand(id);
    //        result = await _mediator.Send(command, cancellationToken);
    //    }

    //    return StatusCode(result.StatusCode, result);
    //}

    #endregion

    #region Queries

    #endregion
}
