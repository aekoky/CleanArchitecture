using CleanArchitecture.Application.Application.ProblemCategories.Queries.GetProblemCategoriesFiltered;
using CleanArchitecture.Application.Application.ProblemCategories.Commands.DeleteProblemCategories;
using CleanArchitecture.Application.Application.ProblemCategories.Commands.DeleteProblemCategory;
using CleanArchitecture.Application.Application.ProblemCategories.Commands.CreateProblemCategory;
using CleanArchitecture.Application.Application.ProblemCategories.Commands.UpdateProblemCategory;
using CleanArchitecture.Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

public class ProblemCategoriesController : ApiControllerBase
{

    [HttpGet("filtred")]
    public async Task<ActionResult<List<ProblemCategoryDto>>> GetProblemCategoriesFiltered([FromQuery] GetProblemCategoriesFilteredQuery query, CancellationToken cancellationToken)
    {
        return await Mediator.Send(query, cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateProblemCategoryCommand command, CancellationToken cancellationToken)
    {
        return await Mediator.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateProblemCategoryCommand command, CancellationToken cancellationToken)
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
        await Mediator.Send(new DeleteProblemCategoryCommand(id), cancellationToken);

        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteProblemCategories(DeleteProblemCategoriesCommand deleteProblemCategoriesCommand, CancellationToken cancellationToken)
    {
        await Mediator.Send(deleteProblemCategoriesCommand, cancellationToken);

        return NoContent();
    }
}
