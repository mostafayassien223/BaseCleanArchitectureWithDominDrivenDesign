using MediatR;
using TaskProjectUnitSolution.Domain.Common;

namespace TaskProjectUnitSolution.Application.Projects.Queries.GetProjectListQuery
{
    public class GetProjectListQuery:IRequest<TResponse<GetProjectListQueryResult>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? ProjectCode { get; set; }
        public string? ProjectName { get; set; }
    }
}
