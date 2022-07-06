namespace OpenExam.Application.Common.Interfaces;


public interface IBlobStorageContext
{
    Task AddDocument(string bucketName, string fileName, Stream file);
    
    Task<Stream> GetFile(string bucketName, string fileName);
    
    Task<Stream> GetFile(string filePath);
}
