using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Interfaces
{
    public interface IRoundService
    {
        Task<IReadOnlyList<Round>> ListAllAsync();
        Task<Round> GetByIdAsync(int id);
        Task<Round> AddAsync(Round entity);
        Task<Round> UpdateAsync(Round entity);
        Task<IReadOnlyList<Round>> ListByCvIdAsync(int id);
    }
}
