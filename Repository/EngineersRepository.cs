using astronova.Data;
using astronova.Entities;
using Microsoft.EntityFrameworkCore;

namespace astronova.Repository;

public class EngineersRepository
{
    private readonly AstronovaDbContext _context;

    public EngineersRepository(AstronovaDbContext context)
    {
        _context = context;
    }

    // Get All
    public List<Engineers> GetEngineers()
    {
        return _context.Engineers.ToList();
    }

    // Get By ID
    public Engineers? GetEnginnerById(int id)
    {
        return _context.Engineers.FirstOrDefault(a => a.Id == id);
    }

    // Add
    public void AddEngineer(Engineers engineer)
    {
        try
        {
            _context.Engineers.Add(engineer);
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }
    
    // Update
    public void UpdateEngineer(int id, Engineers engineer)
    {
        var existing = GetEnginnerById(id);
        if (existing == null) return;

        if (engineer.Name != null)
            existing.Name = engineer.Name;

        if (engineer.LastName != null)
            existing.LastName = engineer.LastName;
        
        if (engineer.Specialty != default)
            existing.Specialty = engineer.Specialty;
        
        if (engineer.YearExperience != null)
            existing.YearExperience = engineer.YearExperience;

        _context.SaveChanges();
    }
    
    // Delete By ID
    public bool DeleteEngineer(int id)
    {
        var engineer = GetEnginnerById(id);

        if (engineer == null)
            return false;

        try
        {
            _context.Engineers.Remove(engineer);
            _context.SaveChanges();
            return true;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
        
    }
    
}