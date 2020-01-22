using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Services
{
    public class UserRoundService : IUserRoundService
    {
        private readonly IUserRoundRepository _userRoundRepository;

        public UserRoundService(IUserRoundRepository userRoundRepository)
        {
            this._userRoundRepository = userRoundRepository;
        }
        public async Task AddListAsync(IReadOnlyList<UserRound> userRounds)
        {
            await _userRoundRepository.AddListAsync(userRounds);
        }

        public async Task DeleteByRoundIdAsync(int id)
        {
            await _userRoundRepository.DeleteByRoundIdAsync(id);
        }

        public async Task<IReadOnlyList<UserRound>> GetListByRoundIdAsync(int id)
        {
            return await _userRoundRepository.GetListByRoundIdAsync(id);
        }
    }
}
