using CryptoJackpot.Identity.Data.Context;
using CryptoJackpot.Identity.Domain.Interfaces;
using CryptoJackpot.Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace CryptoJackpot.Identity.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IdentityDbContext _context;
    
    public RoleRepository(IdentityDbContext context)
    {
        _context = context;
    }

    public Task<List<Role>> GetAllRoles()
        => _context.Roles.AsNoTracking().ToListAsync();
}