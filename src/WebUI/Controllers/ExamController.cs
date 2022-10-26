using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenExam.Application.Exam.Commands.CreateExam;
using OpenExam.Application.Exam.Commands.DeleteExam;
using OpenExam.Application.Exam.Commands.UpdateExam;
using OpenExam.Application.Exam.DTOs;
using OpenExam.Application.Exam.Queries.GetSubmissionsByExamWithPaginationQuery;
using OpenExam.Domain.Entities;

namespace OpenExam.WebUI.Controllers;

// [Authorize]
public class ExamController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Exam>>> GetAll()
    {
        return await Mediator.Send(new GetExamsQuery());
    }
    
    [HttpGet("ById")]
    public async Task<ActionResult<ExamReturnDto>> ById([FromQuery] GetExamByIdQuery query)
    {
        return await Mediator.Send(query);
    }
    
    [Authorize]
    [HttpGet("myexams")]
    public async Task<ActionResult<List<Exam>>> MyExams()
    {
        return await Mediator.Send(new GetExamsQuery());
    }
    
    [HttpPost]
    public async Task<Exam> CreateExam([FromQuery] CreateExamCommand query)
    {
        return await Mediator.Send(query);
    }
    
    [HttpPut]
    public async Task<Unit> UpdateExam([FromQuery] UpdateExamCommand query)
    {
        return await Mediator.Send(query);
    }
    
    [HttpDelete]
    public async Task<Unit> DeleteExam([FromQuery] DeleteExamCommand query)
    {
        return await Mediator.Send(query);
    }

    /*[HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoListCommand command)
    {
        return await Mediator.Send(command);
    }*/
}
