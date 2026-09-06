using NewtonAffendi.Course.Domain.Common;
using TaskProjectUnitSolution.Domain.Aggreagte.ProductAggreagte;

namespace TaskProjectUnitSolution.Application.Projects.Queries.GetProjectListQuery
{
    public static class GetProjectListQueryMapping
    {
        public static GetProjectListQueryResult Mappping(this BaseQueryResultModel<Project> projects)
        {

            return new GetProjectListQueryResult()
            {
                Items = projects.Items.Select(e => new GetProjectListDto()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Descrption = e.Descrption,
                    NumberOfUnits = e.NumberOfUnits,
                    ProjectCode = e.ProjectCode,
                    ProjectLocation = e.ProjectLocation,
                }).ToList(),
                TotalCount = projects.TotalCount,

            };

        }
    }
}
