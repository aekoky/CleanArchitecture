using FluentValidation;

namespace CleanArchitecture.Application.Application.ProblemCategories.Commands.DeleteProblemCategories;

public class DeleteProblemCategoriesCommandValidator : AbstractValidator<DeleteProblemCategoriesCommand>
{
    public DeleteProblemCategoriesCommandValidator()
    {
        RuleFor(deleteProblemCategoriesCommand => deleteProblemCategoriesCommand.Ids).NotEmpty();
    }
}
