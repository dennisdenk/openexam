using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Application.Common.Mappings;
using OpenExam.Application.Common.Models;

namespace OpenExam.Application.Users.Queries.GetTodoItemsWithPagination;

public record GetSubmissionsByExamWithPaginationQuery : IRequest<PaginatedList<TodoItemBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetSubmissionsByExamWithPaginationQueryHandler : IRequestHandler<GetSubmissionsByExamWithPaginationQuery, PaginatedList<TodoItemBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSubmissionsByExamWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TodoItemBriefDto>> Handle(GetSubmissionsByExamWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.TodoItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
