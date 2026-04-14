using astronova.Entities.Enums;

namespace astronova.Entities;

public class ExplorationLogs
{
    public int Id { get; set; }
    public string DestinyPlanet { get; set; }
    public string Description { get; set; }
    public RiskLevel RiskLevel  { get; set; }   // Low, Medium, High
    public int MissionId { get; set; }
    public Missions Mission { get; set; }
}