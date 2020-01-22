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
    public class RoundRepository : IRoundRepository
    {
        public readonly RecruitmentManagementContext _db;
        public RoundRepository(RecruitmentManagementContext db)
        {
            this._db = db;
        }
        
        public async Task<Round> AddAsync(Round entity)
        {
            _db.Rounds.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Round entity)
        {
            var entry = _db.Entry(entity);
            _db.Entry(entity).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
        }

        public async Task<Round> GetByIdAsync(int id)
        {
            var round = await _db.Rounds.Include(r=> r.UserRounds)
                .AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return round;
        }

        public async Task<IReadOnlyList<Round>> ListByCVIdAsync(int cVId)
        {
            return await _db.Rounds.Where(u => u.CVId == cVId).ToListAsync();
        }

        public async Task<IReadOnlyList<Round>> ListAllAsync()
        {
            return await _db.Rounds.ToArrayAsync();
        }

        public async Task UpdateAsync(Round entity)
        {
            var entry = _db.Entry(entity);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
