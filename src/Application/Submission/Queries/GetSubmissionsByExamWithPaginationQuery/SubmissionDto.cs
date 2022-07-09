using OpenExam.Application.Common.Mappings;
using OpenExam.Domain.Entities;

namespace OpenExam.Application.Users.Queries.GetTodoItemsWithPagination;

public class SubmissionDto : IMapFrom<Submission>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
