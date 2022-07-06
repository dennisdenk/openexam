using OpenExam.Domain.Common;
using OpenExam.Domain.Entities;

namespace OpenExam.Domain.Events;

public class TodoItemDeletedEvent : BaseEvent
{
    public TodoItemDeletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
