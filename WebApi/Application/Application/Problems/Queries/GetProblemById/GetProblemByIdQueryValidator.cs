using FluentValidation;

namespace CleanArchitecture.Application.Application.Problems.Queries.GetProblemById;

public class GetProblemByIdQueryValidator : AbstractValidator<GetProblemByIdQuery>
{
    public GetProblemByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("Id is required for this query.");
    }
}
