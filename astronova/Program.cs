using astronova.Data;
using astronova.Entities;
using astronova.Entities.Enums;
using astronova.Repository;


var context = new AstronovaDbContext();
var astronautRepository = new AstronautsRepository(context);

// astronautRepository.AddAstronaut(new Astronauts()
// {
//     Name = "Astronaut",
//     HoursExperience = 5,
//     Id = 1,
//     LastName = "Astronov",
//     Range = AstronautRank.Commander
// });





var astros = astronautRepository.GetAstronauts();

foreach (var astro in astros)
{
    Console.WriteLine(@$"
    Id: {astro.Id}
    Name: {astro.Name}
    LastName: {astro.LastName}
    HoursExperience: {astro.HoursExperience}
    Range: {astro.Range}
    ");
}


Console.WriteLine();

