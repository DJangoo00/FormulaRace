namespace Core.Entities;

public partial class TeamDriver
{
    public int IdTeam { get; set; }
    public Team Team { get; set; }
    public int IdDriver { get; set; }
    public Driver Driver { get; set; }

}