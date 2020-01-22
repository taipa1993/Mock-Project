using Microsoft.EntityFrameworkCore;
using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMT.Infrastructure.Data
{
    public class UserRoundRepository : IUserRoundRepository
    {
        public readonly RecruitmentManagementContext _db;
        public UserRoundRepository(RecruitmentManagementContext db)
        {
            this._db = db;
        }
        public async Task DeleteByRoundIdAsync(int id)
        {
            var userRounds =  _db.UserRounds.Where(ur => ur.RoundId == id).ToList();
            _db.UserRounds.RemoveRange(userRounds);
            await _db.SaveChangesAsync();
        }

        public async Task<UserRound> AddAsync(UserRound userRound)
        {
            _db.UserRounds.Add(userRound);
            await _db.SaveChangesAsync();
            return userRound;
        }

        public async Task<IReadOnlyList<UserRound>> GetListByRoundIdAsync(int id)
        {
            var userRounds = _db.UserRounds.AsQueryable();
            return await _db.UserRounds.Where(ur => ur.RoundId == id).Include(ur=>ur.User).ToListAsync();
        }

        public async Task AddListAsync(IReadOnlyList<UserRound> userRounds)
        {
            await _db.UserRounds.AddRangeAsync(userRounds);
            _db.SaveChanges();
        }
    }
}
