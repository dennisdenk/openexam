using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenExam.Application.Common.Exceptions;
using OpenExam.Application.Common.Interfaces;

namespace OpenExam.Application.Files.Commands.DeleteExam;

public record DeleteExamCommand(string Id) : IRequest;

public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteExamCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Exams
            .FirstOrDefaultAsync(e => e.ExamId.Equals(request.Id), cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Exam), request.Id);
        }

        _context.Exams.Remove(entity);

        // entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
