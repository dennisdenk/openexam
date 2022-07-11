using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenExam.Application.TodoLists.Commands.CreateTodoList;
using OpenExam.Application.TodoLists.Commands.DeleteTodoList;
using OpenExam.Application.TodoLists.Commands.UpdateTodoList;
using OpenExam.Application.TodoLists.Queries.ExportTodos;
using OpenExam.Application.TodoLists.Queries.GetTodos;
using OpenExam.Domain.Entities;

namespace OpenExam.WebUI.Controllers;

// [Authorize]
public class ExamController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Submission>>> Get()
    {
        return await Mediator.Send(new GetTodosQuery());
    }

    [HttpGet("{id}")]
    public async Task<FileResult> Get(int id)
    {
        var vm = await Mediator.Send(new ExportTodosQuery { ListId = id });

        return File(vm.Content, vm.ContentType, vm.FileName);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoListCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateTodoListCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTodoListCommand(id));

        return NoContent();
    }
}
