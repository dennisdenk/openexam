using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenExam.Application.Submission.Queries.GetSubmissionsByExamWithPaginationQuery;
using OpenExam.Application.TodoLists.Commands.CreateTodoList;
using OpenExam.Application.TodoLists.Commands.DeleteTodoList;
using OpenExam.Application.TodoLists.Commands.UpdateTodoList;
using OpenExam.Application.TodoLists.Queries.ExportTodos;
using OpenExam.Application.TodoLists.Queries.GetTodos;
using OpenExam.Domain.Entities;

namespace OpenExam.WebUI.Controllers;

// [Authorize]
public class SubmissionController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Submission>>> GetByExamId([FromQuery] GetSubmissionsByExamWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
    
    /* [Authorize]
    [HttpGet("mysubmissions")]
    public async Task<ActionResult<List<Submission>>> GetMySubmissions()
    {
        return await Mediator.Send(query);
    } */

    /*[HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoListCommand command)
    {
        return await Mediator.Send(command);
    }*/
}
