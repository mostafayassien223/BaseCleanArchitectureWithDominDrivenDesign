using System.Xml.Linq;
using TaskProjectUnitSolution.Domain.Aggreagte.ProductAggreagte;

namespace TaskProjectUnitSolution.Domain.Aggreagte.ProjectAggreagte
{
    public class Units: AuditableEntity<Guid>
    {
        public string Descrption { get; private set; }
        public string Location { get; private set; }
        public int UnitArea { get; private set; }
        public int NumberOfRooms { get; private set; }
        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; }
        public Units()
        {
            Id = Guid.NewGuid();
        }
        private Units(string descrption, string location, int unitarea, int numberofrooms) : this()
        {
            Descrption = descrption;
            Location = location;
            UnitArea = unitarea;
            NumberOfRooms = numberofrooms;
        }
        public static Units Init(string descrption, string location, int unitarea, int numberofrooms)
        => new Units(descrption, location, unitarea, numberofrooms);

        public void Update(string descrption, string location, int unitarea, int numberofrooms,Guid projectid)
        {
            Descrption = descrption;
            Location = location;
            UnitArea = unitarea;
            NumberOfRooms = numberofrooms;
            ProjectId = projectid;

        }
    }
}
