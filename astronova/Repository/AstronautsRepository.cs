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
    public Astronauts? GetAstronautsById(int id)
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
    public void UpdateAstronaut(Astronauts astronaut)
    {
        try
        {
            _context.Astronauts.Update(astronaut);
            _context.SaveChanges();

        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }
    
    // Delete By ID
    public bool DeleteAstronaut(int id)
    {
        var astronaut = GetAstronautsById(id);

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