using System.ComponentModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using OpenExam.Application.Common.Interfaces;
using DateTimeConverter = OpenExam.Application.Common.DateTimeConverter;

namespace OpenExam.Application.Exam.Commands.CreateExam;

public record CreateExamCommand : IRequest<Domain.Entities.Exam>
{
    public string Title { get; set; }
    
    public string ExamFilePath { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public DateTime LatestSubmissionTime { get; set; }
    
    public string? Description { get; set; }
}

public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, Domain.Entities.Exam>
{
    private readonly IApplicationDbContext _context;

    public CreateExamCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Exam> Handle(CreateExamCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Exam()
        {
            FileName = request.ExamFilePath,
            Title = request.Title,
            StartTime = DateTimeConverter.ConvertFromDateTimeToLocalDateTime(request.StartTime),
            EndTime = DateTimeConverter.ConvertFromDateTimeToLocalDateTime(request.EndTime),
            LatestSubmissionTime = DateTimeConverter.ConvertFromDateTimeToLocalDateTime(request.LatestSubmissionTime),
            Description = request.Description
        };


        var examFile = await _context.FileUploads.FirstOrDefaultAsync(fu => fu.FilePath.Equals(request.ExamFilePath), cancellationToken: cancellationToken);

        entity.ExamFile = examFile;

        // entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.Exams.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
