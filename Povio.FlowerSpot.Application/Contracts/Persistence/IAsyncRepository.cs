﻿namespace Povio.FlowerSpot.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyCollection<T>> GetAllAsync();
    }
}
