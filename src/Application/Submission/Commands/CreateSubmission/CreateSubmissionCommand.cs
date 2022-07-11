using MediatR;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Domain.Entities;
using OpenExam.Domain.Events;

namespace OpenExam.Application.Submission.Commands.CreateSubmission;

public record CreateSubmissionCommand : IRequest<int>
{
    public int ListId { get; init; }

    public string? Title { get; init; }
}

public class CreateSubmissionCommandHandler : IRequestHandler<CreateSubmissionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSubmissionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSubmissionCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            ListId = request.ListId,
            Title = request.Title,
            Done = false
        };

        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.TodoItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
