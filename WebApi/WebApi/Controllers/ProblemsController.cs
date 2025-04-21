using CleanArchitecture.Application.Application.Problems.Queries.GetProblemSuggestions;
using CleanArchitecture.Application.Application.Problems.Commands.DeleteProblems;
using CleanArchitecture.Application.Application.Problems.Commands.DeleteProblem;
using CleanArchitecture.Application.Application.Problems.Commands.CreateProblem;
using CleanArchitecture.Application.Application.Problems.Commands.UpdateProblem;
using CleanArchitecture.Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Application.ProblemCatalogs.Queries.GetAllProblemCatalogs;
using CleanArchitecture.Application.Application.Problems.Queries.GetAllProblems;
using CleanArchitecture.Application.Application.Problems.Queries.GetProblemsByCategory;

namespace CleanArchitecture.WebApi.Controllers;

public class ProblemsController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IList<ProblemDto>>> GetProblems([FromQuery] GetAllProblemsQuery query, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }

    [HttpGet("suggestions")]
    public async Task<ActionResult<ICollection<ProblemDto>>> GetProblemSuggestions([FromQuery] GetProblemSuggestionsQuery query, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }

    [HttpGet("categories")]
    public async Task<ActionResult<ProblemCategoriesDto>> GetProblemCatalogs(CancellationToken cancellationToken)
    {
        return await Mediator.Send(new GetProblemCatalogsQuery(), cancellationToken);
    }

    [HttpGet("filtred")]
    public async Task<ActionResult<List<ProblemDto>>> GetProblemsByCategory([FromQuery] GetProblemsByCategoryQuery query, CancellationToken cancellationToken)
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
