using OpenExam.Domain.Common;
using OpenExam.Domain.Entities;

namespace OpenExam.Domain.Events;

public class SubmissionCreatedEvent : BaseEvent
{
    public SubmissionCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
