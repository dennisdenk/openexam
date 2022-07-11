using NodaTime;
using OpenExam.Domain.Common;
using OpenExam.Domain.Enums;
using OpenExam.Domain.Events;

namespace OpenExam.Domain.Entities;

public class FileUpload : BaseAuditableEntity
{
    public Guid FileId { get; set; }
    
    public string? FileName { get; set; }
    
    public string? FileType { get; set; }

    public string? FilePath { get; set; }
    
    public string? UploadedBy { get; set; }
    
    // Todo: Checken ob sinnvoll zu speichern oder jedes mal neu zu kalkulieren. Anpassen, dass nur beim erstellen änderbar (falls möglich)
    public string? Checksum { get; set; }

    public LocalDateTime UploadedAt { get; set; }
    
    public string? Comment { get; set; }
    
}
