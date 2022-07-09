using OpenExam.Domain.Common;
using OpenExam.Domain.Enums;
using OpenExam.Domain.Events;

namespace OpenExam.Domain.Entities;

public class User : BaseAuditableEntity
{
    public int ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    private bool _done;
    /*public bool Done
    {
        get => _done;
        set
        {
            if (value == true && _done == false)
            {
                AddDomainEvent(new TodoItemCompletedEvent(this));
            }

            _done = value;
        }
    }*/

    public TodoList List { get; set; } = null!;
}
