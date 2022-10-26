using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Domain.Entities;
using OpenExam.Domain.Events;

namespace OpenExam.Application.Submission.Commands.CreateSubmission;

public record BulkCreateSubmissionCommand : IRequest<List<Domain.Entities.Submission>>
{
   // public string SubmitterId { get; set; }
    
    // public Guid? ExamineeId { get; set; }
    // public ICollection<UserAccount>? Correctors { get; set; }

    // public string FileId { get; set; }

    // public string? Note { get; set; }
    
    // public string ExamId { get; set; }

    // public LocalDateTime SubmittedAt { get; set; }
    
    public List<SubmissionBulkCreateDto> Submissions { get; set; }
    
    public SubmitterType SubmitterType { get; set; }
    
    public string ExamId { get; set; }
}

public class BulkCreateSubmissionCommandHandler : IRequestHandler<BulkCreateSubmissionCommand, List<Domain.Entities.Submission>>
{
    private readonly IApplicationDbContext _context;

    public BulkCreateSubmissionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Domain.Entities.Submission>> Handle(BulkCreateSubmissionCommand request, CancellationToken cancellationToken)
    {
        var examIdParsed = Guid.Empty;
        try
        {
            examIdParsed = Guid.Parse(request.ExamId);
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentException("PrüfungsId hat falsches Format");
        }

        var exam = await _context.Exams.FirstOrDefaultAsync(exm =>
            exm.ExamId == examIdParsed, cancellationToken);
        
        if(exam == null) throw new ValidationException("Keine gültige Prüfungs-Id übergeben");
        
        request.Submissions.ForEach(subm =>
        {
            var entity = new Domain.Entities.Submission()
            {
                Exam = exam
            };
            _context.Submissions.Add(entity);
        });
        
        // entity.AddDomainEvent(new TodoItemCreatedEvent(entity));
        
        // _context.Submissions.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        var examNeu = await _context.Exams.Include(ex => ex.Submissions)
            .FirstOrDefaultAsync(ex => ex.ExamId.Equals(examIdParsed), cancellationToken);

        var allInCurrentExam = examNeu?.Submissions.ToList();

        if (allInCurrentExam != null)
        {
            return allInCurrentExam;
        }

        return new List<Domain.Entities.Submission>();
    }
}
