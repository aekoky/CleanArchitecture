using FluentValidation;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.CreateProblemCategory;

public class CreateProblemCategoryCommandValidator : AbstractValidator<CreateProblemCategoryCommand>
{
    public CreateProblemCategoryCommandValidator()
    {
        RuleFor(problemCategory => problemCategory.Name).NotEmpty().MaximumLength(255);

        RuleFor(problemCategory => problemCategory.Description).MaximumLength(1500);
    }
}
