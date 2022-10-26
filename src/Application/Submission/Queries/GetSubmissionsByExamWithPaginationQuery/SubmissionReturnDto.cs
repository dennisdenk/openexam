using NodaTime;
using OpenExam.Domain.Entities;

namespace OpenExam.Application.Submission.Queries.GetSubmissionsByExamWithPaginationQuery;

public class SubmissionReturnDto
{
    public Guid SubmissionId { get; set; }

    // public Examinee? Submitter { get; set; }
    public string ExamineeId { get; set; }
    
    public SubmitterType SubmitterType { get; set; }

    // public Guid? ExamineeId { get; set; }
    public ICollection<Domain.Entities.UserAccount>? Correctors { get; set; }
    
    public double Grade { get; set; }
    
    public string? CorrectorComment { get; set; }
    
    public bool Graded { get; set; }
    
    public FileUpload? File { get; set; }

    public string? Note { get; set; }
    
    // public Exam? Exam { get; set; }

    public LocalDateTime SubmittedAt { get; set; }
    
    public string? Password { get; set; }
}