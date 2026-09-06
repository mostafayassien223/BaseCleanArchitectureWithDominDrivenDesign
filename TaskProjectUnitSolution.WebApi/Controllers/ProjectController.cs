using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtonAffendi.Course.WebAPI.Controllers;
using TaskProjectUnitSolution.Application.Projects.Commands.AddProjectCommand;
using TaskProjectUnitSolution.Application.Projects.Commands.DeleteProjectCommand;
using TaskProjectUnitSolution.Application.Projects.Commands.EditProjectCommand;
using TaskProjectUnitSolution.Application.Projects.Queries.GetProjectListQuery;
using TaskProjectUnitSolution.Domain.Common;

namespace TaskProjectUnitSolution.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ApiControllerBase
    {
        [HttpPost(template: "AddProject")]
        public async Task<ActionResult<TResponse<string>>> AddProject([FromBody] AddProjectCommand command)
          => Ok(await Mediator.Send(command));

        [HttpPut(template: "UpdateProject")]
        public async Task<ActionResult<TResponse<string>>> UpdateProject([FromBody] EditProjectCommand command)
         => Ok(await Mediator.Send(command));


        [HttpDelete(template: "DeleteProject")]
        public async Task<ActionResult<TResponse<string>>> DeleteProject([FromBody] DeleteProjectCommand command)
        => Ok(await Mediator.Send(command));

        [HttpGet(nameof(GetProjectList))]
        public async Task<ActionResult<TResponse<GetProjectListQueryResult>>>GetProjectList([FromQuery] GetProjectListQuery query)
        => Ok(await Mediator.Send(query));
    }
}
