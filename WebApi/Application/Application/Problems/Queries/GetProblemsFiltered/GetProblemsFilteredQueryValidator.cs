using FluentValidation;

namespace CleanArchitecture.Application.Application.Problems.Queries.GetProblemsFiltered;

public class GetProblemsFilteredQueryValidator : AbstractValidator<GetProblemsFilteredQuery>
{
    public GetProblemsFilteredQueryValidator()
    {
        RuleFor(x => new { x.Keyword, x.ProblemCategoryId, })
            .Must(x => x.Keyword != string.Empty || x.ProblemCategoryId.HasValue)
            .WithMessage("The filter values must not be empty");
    }
}
