using Microsoft.EntityFrameworkCore;
using OpenExam.Domain.Entities;

namespace OpenExam.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    
    DbSet<Domain.Entities.UserAccount> Users { get; }
    
    DbSet<Domain.Entities.Exam> Exams { get; }
    
    DbSet<FileUpload> FileUploads { get; }
    
    DbSet<Domain.Entities.Submission> Submissions { get; }
    
    DbSet<Examinee> Examinees { get; }
    
    DbSet<UserRole> UserRoles { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
