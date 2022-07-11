using NodaTime;
using OpenExam.Domain.Common;
using OpenExam.Domain.Enums;
using OpenExam.Domain.Events;

namespace OpenExam.Domain.Entities;

public class UserRole : BaseAuditableEntity
{
    public Guid RoleId { get; set; }
    
    public string? RoleName { get; set; }
}
