using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _po;
        public PositionService(IPositionRepository po)
        {
            this._po = po;
        }
        public async Task<Position> Add(Position position)
        {
            return await _po.AddAsync(position);
        }

        public async Task DeletePosition(int id)
        {
            Position delete = await _po.GetByIdAsync(id);
            await _po.DeleteAsync(delete);
        }

        public async Task<Position> GetByIdAsync(int id)
        {
            return await _po.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Position>> PositionsAsync()
        {
            return await _po.ListAllAsync();
        }

        public async Task UpdateAsync(Position position)
        {
            await _po.UpdateAsync(position);
        }
    }
}
