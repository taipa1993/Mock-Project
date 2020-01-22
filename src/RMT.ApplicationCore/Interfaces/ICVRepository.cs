using RMT.ApplicationCore.BusinessObject;
using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Interfaces
{
    public interface ICVRepository : IAsyncRepository<CV>
    {
        Task<IReadOnlyList<CV>> GetListPagingAsync(Page page, CVFilter cv);
        Task<int> CVTotalRows();
    }
}
