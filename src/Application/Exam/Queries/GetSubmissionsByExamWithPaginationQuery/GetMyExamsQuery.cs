using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenExam.Application.Common.Exceptions;
using OpenExam.Application.Common.Interfaces;

namespace OpenExam.Application.Exam.Queries.GetSubmissionsByExamWithPaginationQuery;

public record GetMyExamsQuery() : IRequest<List<Domain.Entities.Exam>>
{
    // public string ExamId { get; set; }
}

public class GetMyExamsQueryHandler : IRequestHandler<GetMyExamsQuery, List<Domain.Entities.Exam>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMyExamsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Domain.Entities.Exam>> Handle(GetMyExamsQuery request, CancellationToken cancellationToken)
    {
        var exam = await _context.Exams.ToListAsync(cancellationToken);

        return exam;
        /*return await _context.TodoItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);*/
    }
}