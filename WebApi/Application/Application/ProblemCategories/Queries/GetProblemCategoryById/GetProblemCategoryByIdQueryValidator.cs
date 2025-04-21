using FluentValidation;

namespace CleanArchitecture.Application.Application.ProblemCategories.Queries.GetProblemCategoryById;

public class GetProblemCategoryByIdQueryValidator : AbstractValidator<GetProblemCategoryByIdQuery>
{
    public GetProblemCategoryByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("Id is required for this query.");
    }
}
