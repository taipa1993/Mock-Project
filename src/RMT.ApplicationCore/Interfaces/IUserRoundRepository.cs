using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Interfaces
{
    public interface IUserRoundRepository
    {
        Task<UserRound> AddAsync(UserRound userRound);
        Task DeleteByRoundIdAsync(int id);

        Task AddListAsync(IReadOnlyList<UserRound> userRounds);

        Task<IReadOnlyList<UserRound>> GetListByRoundIdAsync(int id);
    }
}
