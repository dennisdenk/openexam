using MediatR;
using NodaTime;
using OpenExam.Application.Common.Exceptions;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Domain.Entities;

namespace OpenExam.Application.Exam.Commands.UpdateExam;

public record UpdateExamCommand : IRequest
{
    public string Id { get; set; }
    public string Title { get; set; }
    
    public string ExamFilePath { get; set; }
    
    public LocalDateTime StartTime { get; set; }
    
    public LocalDateTime EndTime { get; set; }
    
    public LocalDateTime LatestSubmissionTime { get; set; }
    
    public string? Description { get; set; }
}

public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateExamCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Exams
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Exam), request.Id);
        }

        entity.Title = request.Title;
        entity.FileName = request.ExamFilePath;
        entity.StartTime = request.StartTime;
        entity.EndTime = request.EndTime;
        entity.LatestSubmissionTime = request.LatestSubmissionTime;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
