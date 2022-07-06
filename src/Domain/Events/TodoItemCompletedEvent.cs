using OpenExam.Domain.Common;
using OpenExam.Domain.Entities;

namespace OpenExam.Domain.Events;

public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemCompletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
