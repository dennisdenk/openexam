using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Domain.Entities;
using OpenExam.Domain.Events;

namespace OpenExam.Application.Submission.Commands.CreateSubmission;

public record UpdateSubmissionCommand : IRequest<Domain.Entities.Submission>
{
    public string SubmisionId { get; set; }
    public string SubmitterId { get; set; }

    public string FileId { get; set; }

    public string ExamId { get; set; }
    
    public string? Note { get; set; }

    // public LocalDateTime SubmittedAt { get; set; }
}

public class UpdateSubmissionCommandHandler : IRequestHandler<UpdateSubmissionCommand, Domain.Entities.Submission>
{
    private readonly IApplicationDbContext _context;

    public UpdateSubmissionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Submission> Handle(UpdateSubmissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Submissions.FirstOrDefaultAsync(sbm => sbm.SubmissionId.ToString() == request.SubmisionId &&
                                                                     sbm.Exam.ExamId.ToString() == request.ExamId);
        
        
        // if(entity.Exam == null) throw new ValidationException("Keine gültige Prüfungs-Id übergeben");
        // if(entity.Submitter == null) throw new ValidationException("Keine gültige Benutzer-Id übergeben");
        // if(entity.File == null) throw new ValidationException("Datei nicht gefunden");

        // TODO: Evtl Event feuern um an Admins Uploadmeldung zu senden
        // entity.AddDomainEvent(new TodoItemCreatedEvent(entity));
        
        entity.File = await _context.FileUploads.FirstOrDefaultAsync(f => f.FileId.ToString() == request.FileId, cancellationToken: cancellationToken);
        entity.Note = request.Note;
        
        
        _context.Submissions.Update(entity);
        
        
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
