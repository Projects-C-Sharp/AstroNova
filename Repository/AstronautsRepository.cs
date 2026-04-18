using astronova.Data;
using astronova.Entities;
using Microsoft.EntityFrameworkCore;

namespace astronova.Repository;

public class AstronautsRepository
{
    private readonly AstronovaDbContext _context;

    public AstronautsRepository(AstronovaDbContext context)
    {
        _context = context;
    }

    // Get All
    public List<Astronauts> GetAstronauts()
    {
        return _context.Astronauts.ToList();
    }

    // Get By ID
    public Astronauts? GetAstronautById(int id)
    {
        return _context.Astronauts.FirstOrDefault(a => a.Id == id);
    }

    // Add
    public void AddAstronaut(Astronauts astronaut)
    {
        try
        {
            _context.Astronauts.Add(astronaut);
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }
    
    // Update
    public void UpdateAstronaut(int id, Astronauts astronaut)
    {
        var existing = GetAstronautById(id);
        if (existing == null) return;

        if (astronaut.Name != null)
            existing.Name = astronaut.Name;

        if (astronaut.LastName != null)
            existing.LastName = astronaut.LastName;

        if (astronaut.HoursExperience.HasValue)
            existing.HoursExperience = astronaut.HoursExperience;
        
        if (astronaut.Range != default)
            existing.Range = astronaut.Range;
        
        if (astronaut.Missions != null)
            existing.Missions = astronaut.Missions;

        _context.SaveChanges();
    }
    
    // Delete By ID
    public bool DeleteAstronaut(int id)
    {
        var astronaut = GetAstronautById(id);

        if (astronaut == null)
            return false;

        try
        {
            _context.Astronauts.Remove(astronaut);
            _context.SaveChanges();
            return true;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
        
    }

}