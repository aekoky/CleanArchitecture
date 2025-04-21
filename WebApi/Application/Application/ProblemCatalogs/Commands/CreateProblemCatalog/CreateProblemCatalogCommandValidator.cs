using FluentValidation;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Commands.CreateProblemCatalog;

public class CreateProblemCatalogCommandValidator : AbstractValidator<CreateProblemCatalogCommand>
{
    public CreateProblemCatalogCommandValidator()
    {
        RuleFor(problemCatalog => problemCatalog.Name).NotEmpty().MaximumLength(255);

        RuleFor(problemCatalog => problemCatalog.Description).MaximumLength(1500);
    }
}
