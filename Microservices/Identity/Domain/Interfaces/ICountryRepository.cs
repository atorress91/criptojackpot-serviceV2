using CryptoJackpot.Identity.Domain.Models;
namespace CryptoJackpot.Identity.Domain.Interfaces;

public interface ICountryRepository
{
    Task<List<Country>> GetAllCountries();
}