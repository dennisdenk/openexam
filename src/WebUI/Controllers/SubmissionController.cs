using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenExam.Application.Submission.Commands.CreateSubmission;
using OpenExam.Application.Submission.Queries.GetSubmissionsByExamWithPaginationQuery;
using OpenExam.Application.Submission.Queries.Submissions;
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

    [HttpPost("VerifySubmission")]
    public async Task<ActionResult<bool>> GetByExamId([FromQuery] SubmissionLoginDto query)
    {
        var mediatorQuery = new VerifyUserOnSubmissionQuery(){SubmissionId = query.SubmissionId, Password = query.Password};
        
        return await Mediator.Send(mediatorQuery);
    }

    /// <summary>
    /// Creates multiple submissions for a given exam
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("BulkCreateSubmissions")]
    public async Task<ActionResult<List<Submission>>> CreateBulkSubmissions([FromBody] BulkCreateSubmissionCommand command)
    {
        return await Mediator.Send(command);
    }
    
    /// <summary>
    /// Update Submission for Students
    /// TODO: Implement for admins
    /// </summary>
    /// <param name="Note">Comment for Submission</param>
    /// <returns>The updated Submission Item</returns>
    /// TODO: Change returntype to submissionupdateDTO
    [HttpPost("UpdateSubmission")]
    public async Task<ActionResult<Submission>> UpdateSubmission([FromQuery] UpdateSubmissionCommand query)
    {
        return await Mediator.Send(query);
    }
    
    [HttpPost("UpdateSubmissionAdmin")]
    public async Task<ActionResult<Submission>> UpdateSubmissionAdmin([FromQuery] UpdateSubmissionCommand query)
    {
        throw new NotImplementedException();
        // return await Mediator.Send(query);
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
