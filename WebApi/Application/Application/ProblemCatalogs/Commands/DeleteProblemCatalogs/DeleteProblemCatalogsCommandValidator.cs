using FluentValidation;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.DeleteProblemCatalogs;

public class DeleteProblemCatalogsCommandValidator : AbstractValidator<DeleteProblemCatalogsCommand>
{
    public DeleteProblemCatalogsCommandValidator()
    {
        RuleFor(deleteProblemCatalogsCommand => deleteProblemCatalogsCommand.Ids).NotEmpty();
    }
}
