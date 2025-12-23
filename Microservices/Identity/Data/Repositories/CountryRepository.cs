using CryptoJackpot.Identity.Data.Context;
using CryptoJackpot.Identity.Domain.Interfaces;
using CryptoJackpot.Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace CryptoJackpot.Identity.Data.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly IdentityDbContext _context;

    public CountryRepository(IdentityDbContext context)
    {
        _context = context;
    }

    public Task<List<Country>> GetAllCountries()
        => _context.Countries.AsNoTracking().ToListAsync();
}