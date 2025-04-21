using CleanArchitecture.Application.Application.ProblemCatalogs.Commands.DeleteProblemCatalogs;
using CleanArchitecture.Application.Application.ProblemCatalogs.Commands.DeleteProblemCatalog;
using CleanArchitecture.Application.Application.ProblemCatalogs.Commands.CreateProblemCatalog;
using CleanArchitecture.Application.Application.ProblemCatalogs.Commands.UpdateProblemCatalog;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

public class ProblemCatalogsController : ApiControllerBase
{

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateProblemCatalogCommand command, CancellationToken cancellationToken)
    {
        return await Mediator.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateProblemCatalogCommand command, CancellationToken cancellationToken)
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
        await Mediator.Send(new DeleteProblemCatalogCommand(id), cancellationToken);

        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteProblemCatalogs(DeleteProblemCatalogsCommand deleteProblemCatalogsCommand, CancellationToken cancellationToken)
    {
        await Mediator.Send(deleteProblemCatalogsCommand, cancellationToken);

        return NoContent();
    }
}
