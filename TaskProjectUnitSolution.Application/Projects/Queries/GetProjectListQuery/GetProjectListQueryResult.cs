namespace TaskProjectUnitSolution.Application.Projects.Queries.GetProjectListQuery
{
    public class GetProjectListQueryResult
    {
       
        public List<GetProjectListDto> Items { get; set; } 
        public int TotalCount { get; set; }

    }

    public class GetProjectListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProjectCode { get; set; }
        public string Descrption { get; set; }
        public string ProjectLocation { get; set; }
        public int NumberOfUnits { get; set; }
    }

}
