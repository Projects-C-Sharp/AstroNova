using astronova.Data;
using astronova.Entities;
using Microsoft.EntityFrameworkCore;

namespace astronova.Repository;

public class ExplorationLogsRepository
{
    private readonly AstronovaDbContext _context;
    public ExplorationLogsRepository(AstronovaDbContext context)
    {
        _context = context;
    }

    // Get All
    public List<ExplorationLogs> GetExplorationLogs()
    {
        return _context.ExplorationLogs.ToList();
    }

    // Get By ID
    public ExplorationLogs? GetExplorationLogById(int id)
    {
        return _context.ExplorationLogs.FirstOrDefault(a => a.Id == id);
    }

    // Add
    public void AddExplorationLog(ExplorationLogs explorationLog)
    {
        try
        {
            _context.ExplorationLogs.Add(explorationLog);
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }
    
    // Update
    public void UpdateExplorationLog(int id, ExplorationLogs explorationLog)
    {
        var existing = GetExplorationLogById(id);
        if (existing == null) return;

        if (explorationLog.DestinyPlanet != null)
            existing.DestinyPlanet = explorationLog.DestinyPlanet;

        if (explorationLog.Description != null)
            existing.Description = explorationLog.Description;
        
        if (explorationLog.RiskLevel != default)
            existing.RiskLevel = explorationLog.RiskLevel;
        
        if (explorationLog.MissionId != null)
            existing.MissionId = explorationLog.MissionId;

        _context.SaveChanges();
    }
    
    // Delete By ID
    public bool DeleteExplorationLog(int id)
    {
        var explorationLog = GetExplorationLogById(id);

        if (explorationLog == null)
            return false;

        try
        {
            _context.ExplorationLogs.Remove(explorationLog);
            _context.SaveChanges();
            return true;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
        
    }
    
}