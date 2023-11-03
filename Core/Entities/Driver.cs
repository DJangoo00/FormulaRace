namespace Core.Entities;

public partial class Driver
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public int IdTeam { get; set; }

    public ICollection<TeamDriver> TeamsDrivers { get; set; } = new List<TeamDriver>();
}
