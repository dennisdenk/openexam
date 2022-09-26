using System.ComponentModel.DataAnnotations;

namespace OpenExam.Domain.Entities;

public class UserRole : BaseAuditableEntity
{
    [Key]
    public Guid RoleId { get; set; }
    
    public string? RoleName { get; set; }
}
