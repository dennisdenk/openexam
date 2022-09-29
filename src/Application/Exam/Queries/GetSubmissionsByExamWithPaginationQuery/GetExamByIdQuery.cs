using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenExam.Application.Common.Exceptions;
using OpenExam.Application.Common.Interfaces;

namespace OpenExam.Application.Exam.Queries.GetSubmissionsByExamWithPaginationQuery;

public record GetExamByIdQuery() : IRequest<Domain.Entities.Exam>
{
    public string ExamId { get; set; }
}

public class GetExamByIdQueryHandler : IRequestHandler<GetExamByIdQuery, Domain.Entities.Exam>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetExamByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Domain.Entities.Exam> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
    {
        // TODO: Einbauen, dass nur der Ersteller des Exams die Ergebnisse sehen kann
        // Wenn User = Admin und die Prüfung erstellt hat alle Infos zurückgeben, auch Abgaben etc
        // Wenn User = Prüfling, nur allgemeine Infos der Prüfung zurückgeben
        var exam = await _context.Exams
            .FirstOrDefaultAsync(exam => exam.ExamId == Guid.Parse(request.ExamId), cancellationToken);
        if (exam == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Exam), request.ExamId);
        }
        return exam;
        /*return await _context.TodoItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);*/
    }
}