using FluentValidation;

namespace CleanArchitecture.Application.Application.Problems.Commands.DeleteProblems;

public class DeleteProblemsCommandValidator : AbstractValidator<DeleteProblemsCommand>
{
    public DeleteProblemsCommandValidator()
    {
        RuleFor(deleteProblemsCommand => deleteProblemsCommand.Ids).NotEmpty();
    }
}
