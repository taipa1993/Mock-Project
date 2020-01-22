using Microsoft.EntityFrameworkCore;
using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.Infrastructure.Data
{
    public class LevelRepository : ILevelRepository
    {
        private readonly RecruitmentManagementContext _db;
        public LevelRepository(RecruitmentManagementContext db)
        {
            this._db = db;
        }
        public async Task<Level> AddAsync(Level entity)
        {
            _db.Levels.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Level entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
        }

        public async Task<Level> GetByIdAsync(int id)
        {
            var level = await _db.Levels.FirstOrDefaultAsync(lv => lv.Id == id);
            return level;
        }

        public async Task<IReadOnlyList<Level>> ListAllAsync()
        {
            return await _db.Levels.ToListAsync();
        }

        public async Task UpdateAsync(Level entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
