using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Application.Exam.Commands.CreateExam;
using OpenExam.Application.Files.Commands;
using OpenExam.Application.Files.Commands.CreateFile;
using OpenExam.Application.TodoLists.Commands.CreateTodoList;
using OpenExam.Application.TodoLists.Commands.DeleteTodoList;
using OpenExam.Application.TodoLists.Commands.UpdateTodoList;
using OpenExam.Application.TodoLists.Queries.ExportTodos;
using OpenExam.Application.TodoLists.Queries.GetTodos;

namespace OpenExam.WebUI.Controllers;

// [Authorize]
public class FileController : ApiControllerBase
{
    
    private readonly IBlobStorageContext _blobStorageContext;
    
    public FileController(IBlobStorageContext blobStorageContext)
    {
        _blobStorageContext = blobStorageContext;
    }

    /*[HttpGet("{id}")]
    public async Task<FileResult> GetFileByPath  (int id)
    {
        var vm = await Mediator.Send(new ExportTodosQuery { ListId = id });

        return File(vm.Content, vm.ContentType, vm.FileName);
    }*/ 
    
    /*[HttpGet]
    public async Task<ActionResult<string>> GetFile([FromQuery] GetFileCommand query)
    {
        // request.File = file;
        // var stream = file.OpenReadStream();
        var ergb = await Mediator.Send(request);
        // await _blobStorageContext.AddDocument(bucketName, file.FileName.Replace('/', '-'), stream); 
        return Ok(ergb);

        // return BadRequest();
    }*/ 
    
    [HttpPost]
    public async Task<ActionResult<string>> UploadFile([FromQuery] CreateFileCommand request)
    {
        // request.File = file;
        // var stream = file.OpenReadStream();
        var ergb = await Mediator.Send(request);
        // await _blobStorageContext.AddDocument(bucketName, file.FileName.Replace('/', '-'), stream); 
        return Ok(ergb);

        // return BadRequest();
    }
    
    [HttpGet("GetFileFromBucket")]
    public async Task<FileStreamResult> GetFileFromBucket([FromQuery] GetFileCommandQuery query)
    {
        var file = await _blobStorageContext.GetFile(query.BucketName, query.FileName);
        return File(file, "application/octet-stream", query.FileName);
        // return await Mediator.Send(query);
    } 

    [HttpPost("UploadFileStream")]
    public async Task<ActionResult<string>> UploadFileStream([FromQuery] CreateFileStreamCommand request)
    {
        var boundary = HeaderUtilities.RemoveQuotes(
            MediaTypeHeaderValue.Parse(Request.ContentType).Boundary
        ).Value;
        var reader = new MultipartReader(boundary, Request.Body);
        var section = await reader.ReadNextSectionAsync();
        string response = string.Empty;
        // var vm = Error;
        try
        {
            request.Reader = reader;
            request.Section = section;
            var vm = await Mediator.Send(request);
            return vm;
        }
        catch (Exception ex)
        {
            return ex.Message;
            //Log ex
            // Console.Error("File Upload Failed");
        }
        return "";
    }
    
    // TODO: Checksumme, Prüfung, Dateiname etc entgegennehmen und speichern, dann beim nachträglichen Hochladen ergänzen
    /* [HttpPost]
    public async Task<ActionResult<int>> AnnounceFile(CreateTodoListCommand command)
    {
        return await Mediator.Send(command);
    } */
}
