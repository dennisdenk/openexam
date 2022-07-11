using System.Reflection;
using OpenExam.Infrastructure.Common;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Domain.Entities;
using OpenExam.Infrastructure.Identity;
using OpenExam.Infrastructure.Persistence.Interceptors;

namespace OpenExam.Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) 
        : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    
    public DbSet<UserAccount> Users => Set<UserAccount>();
    
    public DbSet<Exam> Exams => Set<Exam>();
    
    public DbSet<FileUpload> FileUploads => Set<FileUpload>();
    
    public DbSet<Submission> Submissions => Set<Submission>();
    
    public DbSet<Examinee> Examinees => Set<Examinee>();
    
    public DbSet<UserRole> UserRoles => Set<UserRole>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        /*builder.Entity<Exam>()
            .HasMany(p => p.Examinees)
            .WithMany(p => p.Exam)*/

        builder.Entity<Submission>()
            .HasMany(e => e.Correctors)
            .WithMany(e => e.ExamsToGrade)
            .UsingEntity(j => j.ToTable("SubmissionCorrectors"));
        
        /*builder.Entity<Submission>()
            .HasOne(s => s.Submitter)
            .WithMany(e => e.E)*/
        
        /*builder.Entity<UserAccount>()
            .HasMany(u => u.Submissions)
            .WithOne(s => s.)*/

        /*builder.Entity<Examinee>()
            .HasOne(e => e.Submission)
            .WithOne(s => s.Submitter);*/

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
