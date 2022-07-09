using MediatR;
using OpenExam.Application.Common.Exceptions;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Domain.Entities;
using OpenExam.Domain.Events;

namespace OpenExam.Application.Users.Commands.DeleteUser;

public record DeleteSubmissionCommand(int Id) : IRequest;

public class DeleteSubmissionCommandHandler : IRequestHandler<DeleteSubmissionCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSubmissionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteSubmissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TodoItem), request.Id);
        }

        _context.TodoItems.Remove(entity);

        entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
