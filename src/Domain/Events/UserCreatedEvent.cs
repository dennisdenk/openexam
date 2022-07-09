using OpenExam.Domain.Common;
using OpenExam.Domain.Entities;

namespace OpenExam.Domain.Events;

public class UserCreatedEvent : BaseEvent
{
    public UserCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
