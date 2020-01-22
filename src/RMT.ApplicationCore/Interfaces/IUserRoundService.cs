using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Interfaces
{
    public interface IUserRoundService
    {
        Task DeleteByRoundIdAsync(int id);
        Task AddListAsync(IReadOnlyList<UserRound> userRounds);
        Task<IReadOnlyList<UserRound>> GetListByRoundIdAsync(int id);
    }
}
