using System.ComponentModel.DataAnnotations;
using NodaTime;
using OpenExam.Application.Submission;
using OpenExam.Domain.Common;
using OpenExam.Domain.Enums;
using OpenExam.Domain.Events;

namespace OpenExam.Domain.Entities;

public class Submission : BaseAuditableEntity
{
    [Key]
    public Guid SubmissionId { get; set; }
    
    public Examinee? Submitter { get; set; }
    
    public SubmitterType SubmitterType { get; set; }

    // public Guid? ExamineeId { get; set; }
    public ICollection<UserAccount>? Correctors { get; set; }
    
    public double Grade { get; set; }
    
    public string? CorrectorComment { get; set; }
    
    public bool Graded { get; set; }
    
    public FileUpload? File { get; set; }

    public string? Note { get; set; }
    
    public Exam? Exam { get; set; }

    public LocalDateTime SubmittedAt { get; set; }
    
    public string? Password { get; set; }

    // private bool _done;
    /*public bool Done
    {
        get => _done;
        set
        {
            if (value == true && _done == false)
            {
                AddDomainEvent(new TodoItemCompletedEvent(this));
            }

            _done = value;
        }
    }*/

    // public TodoList List { get; set; } = null!;
}
