using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Interfaces
{
    public interface IRoundRepository : IAsyncRepository<Round>
    {
        Task<IReadOnlyList<Round>> ListByCVIdAsync(int id);
    }
}
