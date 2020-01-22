using Microsoft.EntityFrameworkCore;
using RMT.ApplicationCore.BusinessObject;
using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Generic;
using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMT.Infrastructure.Data
{
    public class CVRepository : ICVRepository
    {
        public readonly RecruitmentManagementContext _db;
        public CVRepository(RecruitmentManagementContext db)
        {
            this._db = db;
        }

        public async Task<CV> AddAsync(CV entity)
        {
            _db.CVs.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CVTotalRows()
        {
            var cvs = _db.CVs.AsQueryable();
            return await cvs.CountAsync();
        }

        public async Task DeleteAsync(CV entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
        }

        public async Task<CV> GetByIdAsync(int id)
        {
            var cv = await _db.CVs
                .Include(a => a.Level)
                .Include(b => b.Position)
                .FirstOrDefaultAsync(c => c.Id == id);
            if(cv != null)
            {
                return cv;
            }
            return null;
        }

        public async Task<IReadOnlyList<CV>> GetListPagingAsync(Page page, CVFilter cv)
        {
            var cvs = _db.CVs.AsQueryable();
            if(cv.LevelId > 0)
            {
                cvs = cvs.Where(c => c.LevelId == cv.LevelId);
            }
            if(cv.PositionId > 0)
            {
                cvs = cvs.Where(c => c.PositionId == cv.PositionId);
            }
            if (!String.IsNullOrEmpty(cv.Status))
            {
                cvs = cvs.Where(c => c.Status == cv.Status);
            }
            if(!String.IsNullOrEmpty(cv.Keyword))
            {
                cvs = cvs.Where(c => c.CandidateName.ToLower().Contains(cv.Keyword));
            }
            return await cvs.Skip((page.CurrentPage - 1) * page.PageSize).Take(page.PageSize)
                .Include(c => c.Position).Include(c => c.Level).ToListAsync();
        }


        public async Task<IReadOnlyList<CV>> ListAllAsync()
        {   
            return await _db.CVs.Include(c => c.Level).Include(c => c.Position).ToListAsync();
        }

        public async Task UpdateAsync(CV entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
