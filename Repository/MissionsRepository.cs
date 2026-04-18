using astronova.Data;
using astronova.Entities;
using Microsoft.EntityFrameworkCore;

namespace astronova.Repository;

public class MissionsRepository
{
    private readonly AstronovaDbContext _context;
    public MissionsRepository(AstronovaDbContext context)
    {
        _context = context;
    }

    // Get All
    public List<Missions> GetMissions()
    {
        return _context.Missions.ToList();
    }

    // Get By ID
    public Missions? GetMissionById(int id)
    {
        return _context.Missions.FirstOrDefault(a => a.Id == id);
    }

    // Add
    public void AddMission(Missions mission)
    {
        try
        {
            _context.Missions.Add(mission);
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }
    
    // Update
    public void UpdateMission(int id, Missions mission)
    {
        var existing = GetMissionById(id);
        if (existing == null) return;

        if (mission.Name != null)
            existing.Name = mission.Name;

        if (mission.LaunchDate != null)
            existing.LaunchDate = mission.LaunchDate;
        
        if (mission.Status != default)
            existing.Status = mission.Status;

        if (mission.AstronautId != null)
            existing.AstronautId = mission.AstronautId;
        
        if (mission.ShipId != null)
            existing.ShipId = mission.ShipId;

        _context.SaveChanges();
    }
    
    // Delete By ID
    public bool DeleteMission(int id)
    {
        var mission = GetMissionById(id);

        if (mission == null)
            return false;

        try
        {
            _context.Missions.Remove(mission);
            _context.SaveChanges();
            return true;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
        
    }
    
}