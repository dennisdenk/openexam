using MediatR;
using OpenExam.Application.Common.Exceptions;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Domain.Entities;

namespace OpenExam.Application.Submission.Commands.UpdateSubmission;

public record UpdateSubmissionCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}

public class UpdateSubmissionCommandHandler : IRequestHandler<UpdateSubmissionCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSubmissionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateSubmissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TodoItem), request.Id);
        }

        entity.Title = request.Title;
        entity.Done = request.Done;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
