using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Domain.Entities;
using OpenExam.Domain.Events;

namespace OpenExam.Application.Submission.Commands.CreateSubmission;

public record CreateSubmissionCommand : IRequest<Domain.Entities.Submission>
{
    public string SubmitterId { get; set; }
    
    // public Guid? ExamineeId { get; set; }
    // public ICollection<UserAccount>? Correctors { get; set; }

    public string FileId { get; set; }

    // public string? Note { get; set; }
    
    public string ExamId { get; set; }

    // public LocalDateTime SubmittedAt { get; set; }
}

public class CreateSubmissionCommandHandler : IRequestHandler<CreateSubmissionCommand, Domain.Entities.Submission>
{
    private readonly IApplicationDbContext _context;

    public CreateSubmissionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Submission> Handle(CreateSubmissionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Submission()
        {
            // TODO: Testen ob es so weit nested funktioniert
            Submitter = await _context.Examinees.FirstOrDefaultAsync(usr => 
                usr.User.UserId ==  Guid.Parse(request.SubmitterId), cancellationToken),
            File = await _context.FileUploads.FirstOrDefaultAsync(f => 
                f.FileId == Guid.Parse(request.FileId), cancellationToken),
            Exam = await _context.Exams.FirstOrDefaultAsync(exm => 
                exm.ExamId == Guid.Parse(request.ExamId), cancellationToken),
            SubmittedAt = LocalDateTime.FromDateTime(DateTime.Now)
        };
        
        if(entity.Exam == null) throw new ValidationException("Keine gültige Prüfungs-Id übergeben");
        if(entity.Submitter == null) throw new ValidationException("Keine gültige Benutzer-Id übergeben");
        if(entity.File == null) throw new ValidationException("Datei nicht gefunden");

        // TODO: Evtl Event feuern um an Admins Uploadmeldung zu senden
        // entity.AddDomainEvent(new TodoItemCreatedEvent(entity));
        

        _context.Submissions.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
