using MediatR;
using Microsoft.Extensions.Logging;
using OpenExam.Domain.Events;

namespace OpenExam.Application.Submission.EventHandlers;

public class SubmissionCreatedEventHandler : INotificationHandler<SubmissionCreatedEvent>
{
    private readonly ILogger<SubmissionCreatedEventHandler> _logger;

    public SubmissionCreatedEventHandler(ILogger<SubmissionCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SubmissionCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
