using astronova.Entities.Enums;

namespace astronova.Entities;

public class Missions
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime LaunchDate { get; set; }
    public MissionStatus Status { get; set; } // Planned, InProgress, Completed, Failed
    
    public int AstronautId { get; set; }
    public Astronauts Astronauts { get; set; }
    
    public int ShipId { get; set; }
    public Ships Ship { get; set; }
    
    public List<ExplorationLogs> ExplorationLogs { get; set; }
    
}