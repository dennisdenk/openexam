using MediatR;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Domain.Entities;
using OpenExam.Domain.Events;

namespace OpenExam.Application.Submission.Commands.CreateSubmission;

public record CreateExamCommand : IRequest<Exam>
{
    public string Title { get; set; }
    
    public string ExamFilePath { get; set; }
    
    public LocalDateTime StartTime { get; set; }
    
    public LocalDateTime EndTime { get; set; }
    
    public LocalDateTime LatestSubmissionTime { get; set; }
    
    public string? Description { get; set; }
}

public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, Exam>
{
    private readonly IApplicationDbContext _context;

    public CreateExamCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Exam> Handle(CreateExamCommand request, CancellationToken cancellationToken)
    {
        var entity = new Exam()
        {
            FileName = request.ExamFilePath,
            Title = request.Title,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            LatestSubmissionTime = request.LatestSubmissionTime
        };


        var examFile = await _context.FileUploads.FirstOrDefaultAsync(fu => fu.FilePath.Equals(request.ExamFilePath), cancellationToken: cancellationToken);

        entity.ExamFile = examFile;

        // entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.Exams.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
