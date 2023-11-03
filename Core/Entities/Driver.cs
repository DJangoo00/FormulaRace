﻿namespace Core.Entities;

public partial class Driver : BaseEntity
{

    public string Name { get; set; }

    public int Age { get; set; }

    public int IdTeam { get; set; }
    public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    public ICollection<TeamDriver> TeamsDrivers { get; set; }
}
