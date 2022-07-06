using OpenExam.Application.Common.Interfaces;

namespace OpenExam.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
