using FluentValidation;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.UpdateProblemCatalog;

public class UpdateProblemCatalogCommandValidator : AbstractValidator<UpdateProblemCatalogCommand>
{
    public UpdateProblemCatalogCommandValidator()
    {
        RuleFor(problemCatalog => problemCatalog.Name).MaximumLength(255).NotEmpty();

        RuleFor(problemCatalog => problemCatalog.Description).MaximumLength(1500);
    }
}
