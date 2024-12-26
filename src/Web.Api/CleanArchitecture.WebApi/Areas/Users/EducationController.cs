using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Features.Education.Command.Create;
using CleanArchitecture.Application.Features.Education.Command.Delete;
using CleanArchitecture.Application.Features.Education.Command.Dtos;
using CleanArchitecture.Application.Features.Education.Command.Update;
using CleanArchitecture.Application.Features.Education.Queries.GetAll;
using CleanArchitecture.Application.Features.Education.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Areas.Users;

public class EducationController : BaseApiController
{
    private readonly IMediator _mediator;
    public EducationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Command

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateEducationDto model, CancellationToken cancellationToken = default)
    {
        var validationResult = new CreateEducationDtoValidator().Validate(model);

        if (!validationResult.IsValid)
        {
            Result result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
            return StatusCode(result.StatusCode, result);
        }
        var command = new CreateEducationCommand(model);
        var _result = await _mediator.Send(command, cancellationToken);

        return StatusCode(_result.StatusCode, _result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateEducationDto model, CancellationToken cancellationToken = default)
    {
        var validationResult = new UpdateEducationDtoValidator().Validate(model);

        if (!validationResult.IsValid)
        {
            Result result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
            return StatusCode(result.StatusCode, result);
        }
        var command = new UpdateEducationCommand(model);
        var _result = await _mediator.Send(command, cancellationToken);

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
            var command = new DeleteEducationCommand(id);
            result = await _mediator.Send(command, cancellationToken);
        }

        return StatusCode(result.StatusCode, result);
    }

    #endregion

    #region Queries

    [HttpGet()]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        Result result;
        var command = new GetAllEducationQuery();
        result = await _mediator.Send(command, cancellationToken);
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
        var command = new GetByIdEducationQuery(id);
        result = await _mediator.Send(command, cancellationToken);
        if (result.Data is null)
        {
            return StatusCode(result.StatusCode, result);
        }
        return StatusCode(result.StatusCode, result);
    }

    #endregion
}
