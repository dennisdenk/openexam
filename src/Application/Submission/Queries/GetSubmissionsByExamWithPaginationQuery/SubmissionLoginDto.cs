using AutoMapper.Configuration.Annotations;
using OpenExam.Application.Common.Mappings;

namespace OpenExam.Application.Submission.Queries.GetSubmissionsByExamWithPaginationQuery;

public class SubmissionLoginDto : IMapFrom<Domain.Entities.Submission>
{
    // [SourceMember("SubmissionId")]
    public Guid SubmissionId { get; set; }

    public string Password { get; set; }
}
