using MediatR;
using TaskProjectUnitSolution.Domain;
using TaskProjectUnitSolution.Domain.Common;

namespace TaskProjectUnitSolution.Application.Projects.Queries.GetProjectListQuery
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, TResponse<GetProjectListQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProjectListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse<GetProjectListQueryResult>>Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.Project.GetProjectList(request.PageNumber,request.PageSize,request.ProjectCode,request.ProjectName);

            return TResponse<GetProjectListQueryResult>.Success(query.Mappping());
        }
    }
}
