using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Services
{
    public class RoundService : IRoundService
    {
        private readonly IRoundRepository _roundRepository;
        public RoundService(IRoundRepository roundRepository)
        {
            this._roundRepository = roundRepository;
        }
        public async Task<Round> AddAsync(Round round)
        {
            var result = await _roundRepository.AddAsync(round);
            return result;
        }

        public async Task<Round> GetByIdAsync(int id)
        {
            var result = await _roundRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<IReadOnlyList<Round>> ListAllAsync()
        {
            var result = await _roundRepository.ListAllAsync();
            return result;
        }

        public async Task<IReadOnlyList<Round>> ListByCvIdAsync(int id)
        {
            var result = await _roundRepository.ListByCVIdAsync(id);
            return result;
        }

        public async Task<Round> UpdateAsync(Round entity)
        {
            entity.UpdateAt = DateTime.Now;
            await _roundRepository.UpdateAsync(entity);
            return entity;
        }
    }
}
