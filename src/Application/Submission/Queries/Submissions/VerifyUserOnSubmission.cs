using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenExam.Application.Common.Interfaces;

namespace OpenExam.Application.Submission.Queries.Submissions;

public record VerifyUserOnSubmissionQuery() : IRequest<bool>
{
    public Guid SubmissionId { get; set; }
    
    public string Password { get; set; }
}

public class VerifyUserOnSubmissionQueryHandler : IRequestHandler<VerifyUserOnSubmissionQuery, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public VerifyUserOnSubmissionQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(VerifyUserOnSubmissionQuery request, CancellationToken cancellationToken)
    {
        // TODO: Wenn User angemeldet ist und der Submission zugeteilt ist, wird kein Passwort benötigt
        var submission = await _context.Submissions.FirstOrDefaultAsync(e => 
            e.SubmissionId.Equals(request.SubmissionId), cancellationToken: cancellationToken);

        // TODO: Checken ob wenn gethrowt wird auch das Programm abbricht
        if (submission == null) throw new ArgumentException("Abgabe nicht gefunden");
        if (submission.Password == "" ) return true;
        return submission.Password == request.Password;
    }
}