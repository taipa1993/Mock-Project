using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Interfaces
{
    public interface ILevelService
    {
        Task<IReadOnlyList<Level>> GetListAsync();
        Task<Level> AddAsync(Level entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(Level entity);
    }
}
