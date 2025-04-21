using FluentValidation;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.UpdateProblemCategory;

public class UpdateProblemCategoryCommandValidator : AbstractValidator<UpdateProblemCategoryCommand>
{
    public UpdateProblemCategoryCommandValidator()
    {
        RuleFor(problemCategory => problemCategory.Name).MaximumLength(255).NotEmpty();

        RuleFor(problemCategory => problemCategory.Description).MaximumLength(1500);
    }
}
