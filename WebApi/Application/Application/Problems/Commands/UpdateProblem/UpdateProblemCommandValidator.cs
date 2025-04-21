using FluentValidation;

namespace CleanArchitecture.Application.Application.Problems.Commands.UpdateProblem;

public class UpdateProblemCommandValidator : AbstractValidator<UpdateProblemCommand>
{
    public UpdateProblemCommandValidator()
    {
        RuleFor(problem => problem.Name).MaximumLength(255).NotEmpty();

        RuleFor(problem => problem.Description).MaximumLength(1500);
    }
}
