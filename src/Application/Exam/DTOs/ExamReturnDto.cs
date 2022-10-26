using System.ComponentModel.DataAnnotations;
using NodaTime;
using OpenExam.Application.Submission.Queries.GetSubmissionsByExamWithPaginationQuery;
using OpenExam.Domain.Entities;

namespace OpenExam.Application.Exam.DTOs;

public class ExamReturnDto
{
    [Key]
    public Guid ExamId { get; set; }
    
    public string Title { get; set; }
    
    // Eher Pfad als Name
    public string? FileName { get; set; }
    
    public FileUpload? ExamFile { get; set; }
    // TODO: Evtl noch umformatieren
    public LocalDateTime StartTime { get; set; }
    
    public LocalDateTime EndTime { get; set; }
    
    public LocalDateTime LatestSubmissionTime { get; set; }
    
    public ICollection<Examinee>? Examinees { get; set; }
    
    public ICollection<Domain.Entities.UserAccount>? Examiner { get; set; } 
    
    public List<SubmissionReturnDto> Submissions { get; set; }

    public string? Description { get; set; }
}