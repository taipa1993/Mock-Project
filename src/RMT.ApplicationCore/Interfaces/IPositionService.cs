using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Interfaces
{
    public interface IPositionService
    {
        Task<Position> Add(Position position);
        Task<IReadOnlyList<Position>> PositionsAsync();
        Task DeletePosition(int id);
        Task<Position> GetByIdAsync(int id);
        Task UpdateAsync(Position position);
    }
}
