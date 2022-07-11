using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Application.Common.Mappings;
using OpenExam.Application.Common.Models;
using OpenExam.Application.UserAccount.Queries.GetTodoItemsWithPagination;

namespace OpenExam.Application.Submission.Queries.GetSubmissionsByExamWithPaginationQuery;

public record GetSubmissionsByExamWithPaginationQuery() : IRequest<List<Domain.Entities.Submission>>
{
    public string ExamId { get; init; }
}

public class GetSubmissionsByExamWithPaginationQueryHandler : IRequestHandler<GetSubmissionsByExamWithPaginationQuery, List<Domain.Entities.Submission>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSubmissionsByExamWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Domain.Entities.Submission>> Handle(GetSubmissionsByExamWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var exam = await _context.Exams.FirstOrDefaultAsync(e => e.ExamId.Equals(request.ExamId), cancellationToken: cancellationToken);

        if (exam?.Submissions != null)
        {
            return exam?.Submissions;
        }

        return new List<Domain.Entities.Submission>();

        /*return await _context.TodoItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);*/
    }
}
