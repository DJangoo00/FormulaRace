namespace Core.Entities;

public partial class Team : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Driver> Drivers { get; set; } = new HashSet<Driver>();
    public ICollection<TeamDriver> TeamsDrivers { get; set; }
}
    