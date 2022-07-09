using FluentValidation;

namespace OpenExam.Application.Users.Commands.UpdateUser;

public class UpdateSubmissionCommandValidator : AbstractValidator<UpdateSubmissionCommand>
{
    public UpdateSubmissionCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
