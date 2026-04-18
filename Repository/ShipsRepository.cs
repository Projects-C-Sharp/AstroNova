using astronova.Data;
using astronova.Entities;
using Microsoft.EntityFrameworkCore;

namespace astronova.Repository;

public class ShipsRepository
{
    private readonly AstronovaDbContext _context;
    public ShipsRepository(AstronovaDbContext context)
    {
        _context = context;
    }

    // Get All
    public List<Ships> GetShips()
    {
        return _context.Ships.ToList();
    }

    // Get By ID
    public Ships? GetShipById(int id)
    {
        return _context.Ships.FirstOrDefault(a => a.Id == id);
    }

    // Add
    public void AddShip(Ships Ship)
    {
        try
        {
            _context.Ships.Add(Ship);
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }
    
    // Update
    public void UpdateShips(int id, Ships Ship)
    {
        var existing = GetShipById(id);
        if (existing == null) return;

        if (Ship.Name != null)
            existing.Name = Ship.Name;

        if (Ship.Model != null)
            existing.Model = Ship.Model;
        
        if (Ship.CrewCapacity != null)
            existing.CrewCapacity = Ship.CrewCapacity;
        
        if (Ship.Status != default)
            existing.Status = Ship.Status;

        _context.SaveChanges();
    }
    
    // Delete By ID
    public bool DeleteShip(int id)
    {
        var ship = GetShipById(id);

        if (ship == null)
            return false;

        try
        {
            _context.Ships.Remove(ship);
            _context.SaveChanges();
            return true;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
        
    }
}