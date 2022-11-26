using OneOf;
using OneOf.Types;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<OneOf<User, None>> AuthenticateAsync(string username, string password);
    }
}