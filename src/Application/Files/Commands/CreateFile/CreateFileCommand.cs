using System.IO.Enumeration;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using OpenExam.Application.Common.Interfaces;

namespace OpenExam.Application.Files.Commands.CreateFile;

public record CreateFileCommand : IRequest<string>
{
    public string? FileName { get; set; }
    
    public string? BucketName { get; set; }
    
    public string? FileType { get; set; }

    public string? FilePath { get; set; }
    
    public IFormFile? File { get; set; }

    public string? Comment { get; set; }
}

public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IBlobStorageContext _blob;

    public CreateFileCommandHandler(IApplicationDbContext context, IBlobStorageContext blobStorageContext)
    {
        _context = context;
        _blob = blobStorageContext;
    }
    
    public async Task<bool> UploadFile(MemoryStream stream, string fileName, string bucketName)
    {
            // var stream = file.OpenReadStream();
            await _blob.AddDocument(bucketName, fileName, stream);
            return true;
    }

    public async Task<string> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        var checksum = "";

        var entity = new Domain.Entities.FileUpload()
        {
            FileName = request.FileName,
            FileType = request.FileType,
            FilePath = request.FilePath,
            Comment = request.Comment
        };
        
        if (request.BucketName == null || request.BucketName.Equals(""))
        {
            request.BucketName = "general";
        }

        if (request.FileName == null || request.FileName.Equals(""))
        {
            entity.FileName = request.File.FileName;
        }
        if (request.FileType == null || request.FileType.Equals(""))
        {
            entity.FileType = request.File.ContentType;
        }

        if (request.FilePath != null && request.FilePath.Contains("/"))
        {
            entity.FileName = request.FilePath.Split("/")[1];
            request.BucketName = request.FilePath.Split("/")[0];
        }
        else
        {
            entity.FilePath = request.BucketName + "/" + request.FileName;
        }
        
        using (var memoryStream = new MemoryStream())
        {
            await request.File.CopyToAsync(memoryStream, cancellationToken);
            memoryStream.Position = 0;
            using (var md5 = MD5.Create())
            {
                var hash = await md5.ComputeHashAsync(request.File.OpenReadStream());
                checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
            // request.File.OpenReadStream()
            await UploadFile(memoryStream ,entity.FileName, request.BucketName);
        }

        entity.Checksum = checksum;




        // var examFile = await _context.FileUploads.FirstOrDefaultAsync(fu => fu.FilePath.Equals(request.ExamFilePath), cancellationToken: cancellationToken);

        // entity.ExamFile = examFile;

        // entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.FileUploads.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Checksum;
    }
}
