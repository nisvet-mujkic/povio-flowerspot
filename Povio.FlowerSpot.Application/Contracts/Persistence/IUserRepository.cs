﻿using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserAsync(string username, string password);
    }
}