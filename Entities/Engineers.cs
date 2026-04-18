using astronova.Entities.Enums;
namespace astronova.Entities;

public class Engineers
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public EngineerSpeciality Specialty  { get; set; }  // propulsion, systems, AI
    public int YearExperience { get; set; }
}