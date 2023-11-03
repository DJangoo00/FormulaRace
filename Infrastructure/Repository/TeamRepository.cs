using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository;
public class TeamRepository : GenericRepository<Team>, ITeam
{
    private readonly ApiContext _context;
    public TeamRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _context.Teams
            .Include(p => p.Drivers)
            .ToListAsync();
    }

    public override async Task<Team> GetByIdAsync(int id)
    {
        return await _context.Teams
            .Include(p => p.Drivers)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}