using FluentValidation;

namespace OpenExam.Application.Users.Commands.CreateUser;

public class CreateSubmissionCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateSubmissionCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
