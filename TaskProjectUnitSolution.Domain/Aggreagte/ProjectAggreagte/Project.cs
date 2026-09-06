using TaskProjectUnitSolution.Domain.Aggreagte.ProjectAggreagte;

namespace TaskProjectUnitSolution.Domain.Aggreagte.ProductAggreagte
{
    public class Project : AuditableEntity<Guid>
    {
        public string Name { get; private set; }
        public string ProjectCode { get; private set; }
        public string Descrption { get; private set; }
        public string ProjectLocation { get; private set; }
        public int NumberOfUnits { get; private set; }
        private readonly List<Units> _units = new();
        public IReadOnlyCollection<Units> Units => _units;
        private Project()
        {
            Id = Guid.NewGuid();

        }
        private Project(string name, string projectCode, string descrption, string projectLocation, int numberOfUnits) : this()
        {
            Name = name;
            ProjectCode = projectCode;
            Descrption = descrption;
            ProjectLocation = projectLocation;
            NumberOfUnits = numberOfUnits;
        }
        public static Project Init(string name, string projectCode, string descrption, string projectLocation, int numberOfUnit)
         => new Project(name, projectCode, descrption, projectLocation, numberOfUnit);

        public void AddUnits(List<Units> units)
        {
            _units.AddRange(units);
        }

        public void Update(string name, string projectCode, string descrption, string projectLocation, int numberOfUnits)
        {
            Name = name;
            ProjectCode =projectCode;
            Descrption = descrption;
            ProjectLocation = projectLocation;
            NumberOfUnits = numberOfUnits;

        }

        public Project UpdateUnits(List<Units> units)
        {
            _units.RemoveAll(x => !units.Any(_ => _.Id == x.Id));

            var updatedUnits = units.Where(x => x.Id != default);

            foreach (var unit in updatedUnits)
                UpdateUnit(unit,Id);

            var addedUnit = units.Where(x => x.Id == default);

            foreach (var unit in addedUnit)
                _units.Add(unit);

            return this;
        }

        public void UpdateUnit(Units unit,Guid projectid)
        {
            var Unit = _units.FirstOrDefault(b => b.Id == unit.Id);
            if (Unit != default)
                Unit.Update(unit.Descrption, unit.Location, unit.UnitArea, unit.NumberOfRooms,projectid);
        }
    }

}
