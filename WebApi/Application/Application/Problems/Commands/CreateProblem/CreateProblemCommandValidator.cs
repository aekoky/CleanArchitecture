using FluentValidation;

namespace CleanArchitecture.Application.Application.Problems.Commands.CreateProblem;

public class CreateProblemCommandValidator : AbstractValidator<CreateProblemCommand>
{
    public CreateProblemCommandValidator()
    {
        RuleFor(problem => problem.Name).NotEmpty().MaximumLength(255);

        RuleFor(problem => problem.Description).MaximumLength(1500);
    }
}
