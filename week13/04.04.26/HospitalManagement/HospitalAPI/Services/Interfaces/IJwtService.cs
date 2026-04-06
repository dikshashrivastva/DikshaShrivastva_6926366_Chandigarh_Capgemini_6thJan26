using HospitalAPI.Models;

namespace HospitalAPI.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}