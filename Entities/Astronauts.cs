using astronova.Entities.Enums;
namespace astronova.Entities;

public class Astronauts
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public AstronautRank Range { get; set; }    // rookie, pilot, commander
    public int? HoursExperience { get; set; }
    
    public List<Missions>? Missions { get; set; }
    
}