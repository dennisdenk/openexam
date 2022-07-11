using FluentValidation;
using OpenExam.Application.UserAccount.Commands.CreateUser;

namespace OpenExam.Application.Submission.Commands.CreateSubmission;

public class CreateSubmissionCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateSubmissionCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
