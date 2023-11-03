namespace Core.Entities;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<TeamDriver> TeamsDrivers { get; set; } = new List<TeamDriver>();
}
