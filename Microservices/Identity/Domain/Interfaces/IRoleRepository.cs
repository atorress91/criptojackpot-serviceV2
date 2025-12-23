using CryptoJackpot.Identity.Domain.Models;
namespace CryptoJackpot.Identity.Domain.Interfaces;

public interface IRoleRepository
{
    Task<List<Role>> GetAllRoles();
}