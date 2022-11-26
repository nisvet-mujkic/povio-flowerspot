using OneOf;
using OneOf.Types;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Application.Contracts.Services;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OneOf<User, None>> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetUserAsync(username, password);

            return user is not null ? user : new None();
        }
    }
}