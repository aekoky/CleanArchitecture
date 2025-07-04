﻿using CleanArchitecture.Application.Application.Problems.Commands.DeleteProblems;
using CleanArchitecture.Application.Application.Problems.Commands.DeleteProblem;
using CleanArchitecture.Application.Application.Problems.Commands.CreateProblem;
using CleanArchitecture.Application.Application.Problems.Commands.UpdateProblem;
using CleanArchitecture.Application.Application.Problems.Queries.GetProblems;
using CleanArchitecture.Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

public class ProblemsController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ProblemsDto>> GetProblems([FromQuery] GetProblemsQuery query, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateProblemCommand command, CancellationToken cancellationToken)
    {
        return await Mediator.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateProblemCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command, cancellationToken);

        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteProblemCommand(id), cancellationToken);

        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteProblems(DeleteProblemsCommand deleteProblemsCommand, CancellationToken cancellationToken)
    {
        await Mediator.Send(deleteProblemsCommand, cancellationToken);

        return NoContent();
    }
}
