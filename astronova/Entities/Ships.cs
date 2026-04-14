using astronova.Entities.Enums;

namespace astronova.Entities;

public class Ships
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public int CrewCapacity { get; set; }
    public ShipStatus Status { get; set; }  // operational, under_maintenance, retired
    
    public List<Missions> Missions { get; set; }
}