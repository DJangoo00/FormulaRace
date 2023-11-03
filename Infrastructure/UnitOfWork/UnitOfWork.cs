using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infraestructure.Repository;
using Infrastructure.Data;

namespace Infraestructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiContext context;
    private TeamRepository _teams;
    private DriverRepository _drivers;

    public UnitOfWork(ApiContext _context)
    {
        context = _context;
    }
    public ITeam Teams
    {
        get{
            if(_teams == null)
            {
                _teams = new TeamRepository(context);
            }
            return _teams;
        }
    }
    public IDriver Drivers
    {
        get{
            if(_drivers == null)
            {
                _drivers = new DriverRepository(context);
            }
            return _drivers;
        }
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}