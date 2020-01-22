using RMT.ApplicationCore.BusinessObject;
using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Services
{
    public class CVService : ICVService
    {
        private readonly ICVRepository _cVRepository;
        public CVService(ICVRepository cv)
        {
            this._cVRepository = cv;
        }
        public async Task<CV> AddAsync(CV cv)
        {
            cv.Status = "Not Process Yet";
            cv.InComingDate = DateTime.Now;
            cv.UpdateAt = DateTime.Now;
            await this._cVRepository.AddAsync(cv);
            return cv;
        }

        public async Task<int> CVTotalRows()
        {
            return await _cVRepository.CVTotalRows();
        }

        public async Task DeleteAsync(int id)
        {
            CV deletedCV = await GetDetailAsync(id);
            if(deletedCV != null)
            {
                await _cVRepository.DeleteAsync(deletedCV);
            }
        }

        public async Task<CV> GetDetailAsync(int id)
        {
            CV cv = await _cVRepository.GetByIdAsync(id);
            if(cv != null)
            {
                return cv;
            }
            return null;
        }

        public async Task<IReadOnlyList<CV>> GetListAsync()
        {
            IReadOnlyList<CV> cVs = await _cVRepository.ListAllAsync();
            return cVs;
        }

        public async Task<IReadOnlyList<CV>> GetListAsyncPaging(Page page, CVFilter cv)
        {
            IReadOnlyList<CV> cvs = await _cVRepository.GetListPagingAsync(page, cv);
            return cvs;
        }

        public async Task UpdateAsync(CV cv)
        {
            cv.UpdateAt = DateTime.Now;
            await _cVRepository.UpdateAsync(cv);         
        }
    }
}
