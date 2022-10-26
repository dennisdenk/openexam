using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenExam.Application.Common.Exceptions;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Application.Common.Mappings;
using OpenExam.Application.Exam.DTOs;
using OpenExam.Application.Submission.Queries.GetSubmissionsByExamWithPaginationQuery;

namespace OpenExam.Application.Exam.Queries.GetSubmissionsByExamWithPaginationQuery;

public record GetExamByIdQuery() : IRequest<ExamReturnDto>
{
    public string ExamId { get; set; }
}

public class GetExamByIdQueryHandler : IRequestHandler<GetExamByIdQuery, ExamReturnDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetExamByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ExamReturnDto> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
    {
        // TODO: Einbauen, dass nur der Ersteller des Exams die Ergebnisse sehen kann
        // Wenn User = Admin und die Prüfung erstellt hat alle Infos zurückgeben, auch Abgaben etc
        // Wenn User = Prüfling, nur allgemeine Infos der Prüfung zurückgeben
       
        // TODO: Performance prüfen, notfalls nach alternative umschauen
        var exam = await _context.Exams
            // .Include(exm => exm.Examinees)
            // .Include(exm => exm.Submissions)
            // .ThenInclude(subm => subm.Correctors)
            // .ThenInclude(subm => subm.File)
            .FirstOrDefaultAsync(exam => exam.ExamId == Guid.Parse(request.ExamId), cancellationToken);

        if (exam == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Exam), request.ExamId);
        }
        
        // Mapping Configuration

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Domain.Entities.Submission, SubmissionReturnDto>()
            .ForMember(dest => dest.ExamineeId,
                opt => opt.MapFrom(src => src.Submitter.ExamineeId)));
        /* var configExam = new MapperConfiguration(cfg => cfg.CreateMap<Domain.Entities.Exam, ExamReturnDto>()
            .ForMember(dest => dest.,
                opt => opt.MapFrom(src => src.Submitter.ExamineeId)));*/ 
        


        var mapped = _mapper.Map<Domain.Entities.Exam, ExamReturnDto>(exam);
        
        
        // mapped.Submissions = 
            
            
        
        /* exam.Submissions =
            await _context.Submissions.Where(subm => subm.Exam.ExamId.Equals(exam.ExamId))
            .ProjectToListAsync<SubmissionReturnDto>(config); */
        
        
        return mapped;
        /*return await _context.TodoItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);*/
    }
}