using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OpenExam.Application.Exam.Commands.CreateExam;
using OpenExam.Application.Exam.Commands.DeleteExam;
using OpenExam.Application.Exam.Commands.UpdateExam;
using OpenExam.Application.Exam.Queries.GetSubmissionsByExamWithPaginationQuery;
using OpenExam.Domain.Entities;

namespace OpenExam.WebUI.Controllers;

// [Authorize]
public class ChatController : ApiControllerBase
{
    private readonly IHubContext<SubmissionHub> _hubContext;
    
    public ChatController(IHubContext<SubmissionHub> hubContext)
    {
        _hubContext = hubContext;
    }
    
    /* [HttpGet]
    public async Task<ActionResult<List<Exam>>> GetAll()
    {
        return await Mediator.Send(new GetExamsQuery());
    } */
    
    [HttpPost]
    public async Task<OkResult> SendMessage(string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveSubmission", message);

        return Ok();
    }
}