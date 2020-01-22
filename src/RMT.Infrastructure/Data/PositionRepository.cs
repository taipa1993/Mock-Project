using Microsoft.EntityFrameworkCore;
using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.Infrastructure.Data
{
    public class PositionRepository : IPositionRepository
    {
        private readonly RecruitmentManagementContext _db;

        public PositionRepository(RecruitmentManagementContext db)
        {
            this._db = db;
        }
        public async Task<Position> AddAsync(Position entity)
        {
            _db.Positions.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Position entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
        }

        public async Task<Position> GetByIdAsync(int id)
        {
            Position position = await _db.Positions.FirstOrDefaultAsync(po => po.Id == id);
            return position;
        }

        public async Task<IReadOnlyList<Position>> ListAllAsync()
        {
            return await _db.Positions.ToListAsync();
        }

        public async Task UpdateAsync(Position entity)
        {
            var entry = _db.Entry(entity);
            _db.Entry(entry).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
