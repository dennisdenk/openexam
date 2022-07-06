using OpenExam.Application.TodoLists.Queries.ExportTodos;

namespace OpenExam.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
