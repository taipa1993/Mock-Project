using RMT.ApplicationCore.BusinessObject;
using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Interfaces
{
    public interface ICVService
    {
        Task<IReadOnlyList<CV>> GetListAsync();
        Task<CV> GetDetailAsync(int id);
        Task DeleteAsync(int id);
        Task<CV> AddAsync(CV cv);
        Task UpdateAsync(CV cv);

        Task<IReadOnlyList<CV>> GetListAsyncPaging(Page page, CVFilter cv);
        Task<int> CVTotalRows();

    }
}
