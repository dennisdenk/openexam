using System.Net.Http.Headers;
using System.Security.Cryptography;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using OpenExam.Application.Common.Interfaces;

namespace OpenExam.Application.Files.Commands.CreateFile;

public record CreateFileStreamCommand : IRequest<string>
{
    public string? FileName { get; set; }
    
    public string? BucketName { get; set; }
    
    public string? FileType { get; set; }

    public string? FilePath { get; set; }
    
    public FileStream FileStream { get; set; }
    
    public string? Comment { get; set; }
    
    public MultipartReader Reader { get; set; }
    
    public MultipartSection Section { get; set; }
}

public class CreateFileStreamCommandHandler : IRequestHandler<CreateFileStreamCommand, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IBlobStorageContext _blob;

    public CreateFileStreamCommandHandler(IApplicationDbContext context, IBlobStorageContext blobStorageContext)
    {
        _context = context;
        _blob = blobStorageContext;
    }
    
    public async Task<bool> UploadFile(MultipartReader reader,MultipartSection? section, string fileName, string bucketName)
    {
        using (var memoryStream = new MemoryStream())
        {
            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(
                    section.ContentDisposition, out var contentDisposition
                );
                if (hasContentDispositionHeader)
                {
                    if (contentDisposition.DispositionType.Equals("form-data") &&
                        (!string.IsNullOrEmpty(contentDisposition.FileName) ||
                         !string.IsNullOrEmpty(contentDisposition.FileNameStar)))
                    {
                        string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                        byte[] fileArray;
                    
                        await section.Body.CopyToAsync(memoryStream);
                        
                        fileArray = memoryStream.ToArray();
                    
                    
                        /* using (var fileStream = System.IO.File.Create(Path.Combine(filePath, contentDisposition.FileName)))
                        {
                            await fileStream.WriteAsync(fileArray);
                        } */
                    }
                }
                section = await reader.ReadNextSectionAsync();
            }
            await _blob.AddDocument(bucketName, fileName, memoryStream);
            return true;
        }
    }

    public async Task<string> Handle(CreateFileStreamCommand request, CancellationToken cancellationToken)
    {
        var checksum = "";
        using (var md5 = MD5.Create())
        {
            var hash = await md5.ComputeHashAsync(request.FileStream);
            checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }

        var entity = new Domain.Entities.FileUpload()
        {
            FileName = request.FileName,
            FileType = request.FileType,
            FilePath = request.FilePath,
            Comment = request.Comment,
            Checksum = checksum
        };
            
        if (request.FilePath != null && request.FilePath.Contains("/"))
        {
            entity.FileName = request.FilePath.Split("/")[1];
            request.BucketName = request.FilePath.Split("/")[0];
        }
        else
        {
            entity.FilePath = request.BucketName + "/" + request.FileName;
        }

        await UploadFile(request.Reader, request.Section, entity.FileName, request.BucketName);


        // var examFile = await _context.FileUploads.FirstOrDefaultAsync(fu => fu.FilePath.Equals(request.ExamFilePath), cancellationToken: cancellationToken);

        // entity.ExamFile = examFile;

        // entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.FileUploads.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Checksum;
    }
}
