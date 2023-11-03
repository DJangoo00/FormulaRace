using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository;
public class DriverRepository : GenericRepository<Driver>, IDriver
{
    private readonly ApiContext _context;
    public DriverRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Driver>> GetAllAsync()
    {
        return await _context.Drivers
/*             .Include(p => p.tea)
 */            .ToListAsync();
    }

    public override async Task<Driver> GetByIdAsync(int id)
    {
        return await _context.Drivers
/*             .Include(p => p.Drivers)
 */            .FirstOrDefaultAsync(p => p.Id == id);
    }
}