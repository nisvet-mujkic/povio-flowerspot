using OneOf;
using OneOf.Types;
using Povio.FlowerSpot.Domain.Entities;
using System.Security.Claims;

namespace Povio.FlowerSpot.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<OneOf<User, None>> Authenticate(string username, string password);
    }
}
