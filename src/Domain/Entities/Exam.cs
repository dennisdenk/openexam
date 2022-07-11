using System.ComponentModel.DataAnnotations;
using NodaTime;
using OpenExam.Domain.Common;
using OpenExam.Domain.Enums;
using OpenExam.Domain.Events;

namespace OpenExam.Domain.Entities;

public class Exam : BaseAuditableEntity
{
    public Exam()
    {
        Submissions = new List<Submission>();
    }

    [Key]
    public Guid ExamId { get; set; }
    
    public string Title { get; set; }
    
    // Eher Pfad als Name
    public string? FileName { get; set; }
    
    public FileUpload? ExamFile { get; set; }
    
    public LocalDateTime StartTime { get; set; }
    
    public LocalDateTime EndTime { get; set; }
    
    public LocalDateTime LatestSubmissionTime { get; set; }
    
    public ICollection<Examinee>? Examinees { get; set; }
    
    public ICollection<UserAccount>? Examiner { get; set; } 
    
    public List<Submission> Submissions { get; set; }

    public string? Description { get; set; }
    
}
