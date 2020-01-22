using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Services
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _levelRepository;
        public LevelService(ILevelRepository _levelRepository)
        {
            this._levelRepository = _levelRepository;
        }

        public async Task<Level> AddAsync(Level entity)
        {
            return await _levelRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Level level = await _levelRepository.GetByIdAsync(id);
            if(level != null)
            {
                await _levelRepository.DeleteAsync(level);
            }
        }

        public async Task<IReadOnlyList<Level>> GetListAsync()
        {
            return await _levelRepository.ListAllAsync();
        }

        public async Task UpdateAsync(Level entity)
        {
            await _levelRepository.UpdateAsync(entity);
        }
    }
}
