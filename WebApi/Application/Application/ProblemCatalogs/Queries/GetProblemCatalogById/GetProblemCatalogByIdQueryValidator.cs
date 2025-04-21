using FluentValidation;

namespace CleanArchitecture.Application.Application.ProblemCatalogs.Queries.GetProblemCatalogById;

public class GetProblemCatalogByIdQueryValidator : AbstractValidator<GetProblemCatalogByIdQuery>
{
    public GetProblemCatalogByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("Id is required for this query.");
    }
}
