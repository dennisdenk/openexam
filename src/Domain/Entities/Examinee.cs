using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;
using OpenExam.Domain.Common;
using OpenExam.Domain.Enums;
using OpenExam.Domain.Events;

namespace OpenExam.Domain.Entities;

public class Examinee : BaseAuditableEntity
{
    [Key]
    public Guid ExamineeId { get; set; }
    
    public ExamineeType ExamineeType { get; set; }
    
    public UserAccount? User { get; set; }
    
    // [ForeignKey("Submitter")]
    public List<Submission>? Submissions { get; set; }

    public Exam? Exam { get; set; }
    
    public string? Email { get; set; }
    
    public string? Code { get; set; }

}
