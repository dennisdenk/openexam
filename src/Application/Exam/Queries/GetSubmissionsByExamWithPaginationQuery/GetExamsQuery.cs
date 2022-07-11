using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenExam.Application.Common.Interfaces;

namespace OpenExam.Application.Exam.Queries.GetSubmissionsByExamWithPaginationQuery;

public record GetExamsQuery() : IRequest<List<Domain.Entities.Exam>>
{
    // public string ExamId { get; init; }
}

public class GetExamsQueryHandler : IRequestHandler<GetExamsQuery, List<Domain.Entities.Exam>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetExamsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Domain.Entities.Exam>> Handle(GetExamsQuery request, CancellationToken cancellationToken)
    {
        var exams = await _context.Exams.ToListAsync(cancellationToken);
        return exams;

        /*return await _context.TodoItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);*/
    }
}
