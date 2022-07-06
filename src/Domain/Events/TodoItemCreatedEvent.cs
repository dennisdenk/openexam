using OpenExam.Domain.Common;
using OpenExam.Domain.Entities;

namespace OpenExam.Domain.Events;

public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
