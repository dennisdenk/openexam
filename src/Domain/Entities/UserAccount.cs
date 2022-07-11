using System.ComponentModel.DataAnnotations;
using OpenExam.Domain.Common;
using OpenExam.Domain.Enums;
using OpenExam.Domain.Events;

namespace OpenExam.Domain.Entities;

public class UserAccount : BaseAuditableEntity
{
    public UserAccount()
    {
        Exams = new List<Examinee>();
    }
    
    [Key]
    public Guid UserId { get; set; }

    public string? IdentityServiceId { get; set; }
    
    public ICollection<UserRole>? Roles { get; set; }
    
    // public IList<Submission> Submissions { get; set; }
    
    public List<Examinee> Exams { get; set; }
    
    public IList<Submission> ExamsToGrade { get; set; }
}
