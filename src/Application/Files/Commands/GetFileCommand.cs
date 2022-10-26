using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenExam.Application.Common.Exceptions;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Application.Exam.DTOs;
using OpenExam.Application.Submission.Queries.GetSubmissionsByExamWithPaginationQuery;

namespace OpenExam.Application.Files.Commands;

public record GetFileCommandQuery() : IRequest<FileStreamResult>
{
    public string BucketName { get; set; }
    public string FileName { get; set; }
}

public class GetFileCommandHandler : IRequestHandler<GetFileCommandQuery, FileStreamResult>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IBlobStorageContext _blob;

    public GetFileCommandHandler(IApplicationDbContext context, IMapper mapper, IBlobStorageContext blobStorageContext)
    {
        _context = context;
        _mapper = mapper;
        _blob = blobStorageContext;
    }

    public async Task<FileStreamResult> Handle(GetFileCommandQuery request, CancellationToken cancellationToken)
    {
        // TODO: Trennung von Controllern und Datenlogik
        // var file = await _blob.GetFile(request.BucketName, request.FileName);
        // return File(file, "application/octet-stream", request.FileName);
        throw new NotImplementedException();

        /*return await _context.TodoItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);*/
    }
}