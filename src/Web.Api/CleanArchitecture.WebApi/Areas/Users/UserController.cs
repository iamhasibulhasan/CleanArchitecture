using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Features.Users.Command.Create;
using CleanArchitecture.Application.Features.Users.Command.Delete;
using CleanArchitecture.Application.Features.Users.Command.Dtos;
using CleanArchitecture.Application.Features.Users.Command.Update;
using CleanArchitecture.Application.Features.Users.Queries.GetAll;
using CleanArchitecture.Application.Features.Users.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Areas.Users;

public class UserController : BaseApiController
{

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
        var _result = await Mediator.Send(command, cancellationToken);

        return StatusCode(_result.StatusCode, _result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateUserDto model, CancellationToken cancellationToken = default)
    {
        var validationResult = new UpdateUserDtoValidator().Validate(model);

        if (!validationResult.IsValid)
        {
            Result result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
            return StatusCode(result.StatusCode, result);
        }
        var command = new UpdateUserCommand(model);
        var _result = await Mediator.Send(command, cancellationToken);

        return StatusCode(_result.StatusCode, _result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
    {

        Result result;
        if (id <= 0)
        {
            result = Utility.GetValidationFailedMsg(CommonMessages.InvalidId);
        }
        else
        {
            var command = new DeleteUserCommand(id);
            result = await Mediator.Send(command, cancellationToken);
        }

        return StatusCode(result.StatusCode, result);
    }

    #endregion

    #region Queries

    [HttpGet()]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        Result result;
        var command = new GetAllUserQuery();
        result = await Mediator.Send(command, cancellationToken);
        if (result.Data is null)
        {
            return StatusCode(result.StatusCode, result);
        }
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
    {
        Result result;
        var command = new GetByIdUserQuery(id);
        result = await Mediator.Send(command, cancellationToken);
        if (result.Data is null)
        {
            return StatusCode(result.StatusCode, result);
        }
        return StatusCode(result.StatusCode, result);
    }

    #endregion
}
