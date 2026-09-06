using NewtonAffendi.Course.Domain.Common;
using TaskProjectUnitSolution.Domain.Aggreagte.ProductAggreagte;

namespace TaskProjectUnitSolution.Domain.Repositories
{
    public interface IProjectRepository: IRepository<Project>
    {
        Task<bool> CheckUniqueProjectCode(string projectcode,Guid? projectId=null);
        Task<BaseQueryResultModel<Project>> GetProjectList(int pageNumber, int pageSize, string? projectcode,string? projectname);

        Task<Project> GetProjectById (Guid id);

        Task<bool> CheckProjectExist(Guid id);
    }
}
