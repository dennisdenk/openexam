using OpenExam.Application.Common.Mappings;

namespace OpenExam.Application.Exam.Queries.GetSubmissionsByExamWithPaginationQuery;

public class SubmissionDto : IMapFrom<Domain.Entities.Submission>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
