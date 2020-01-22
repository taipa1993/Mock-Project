using Microsoft.EntityFrameworkCore;
using RMT.ApplicationCore.BusinessObject;
using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMT.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly RecruitmentManagementContext _db;

        public UserRepository(RecruitmentManagementContext db)
        {
            this._db = db;
        }
        public async Task<User> AddAsync(User entity)
        {
            _db.Users.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(User entity)
        {
            User userDelete = new User()
            {
                Id = entity.Id
            };
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<User>> GetAllAsyncPaging(Page page, UserFilter user)
        {
            var users = _db.Users.AsQueryable();
            if (!String.IsNullOrEmpty(user.Role))
            {
                users = users.Where(ur => ur.Role == user.Role);
            }
            if (!String.IsNullOrEmpty(user.Keyword))
            {
                users = users.Where(ur => ur.UserName.ToLower().Contains(user.Keyword));
            }
            return await users.Skip((page.CurrentPage - 1) * page.PageSize).Take(page.PageSize).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            User user = await _db.Users.FirstOrDefaultAsync(ur => ur.Id == id);
            if(user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<IReadOnlyList<User>> Interviewers()
        {
            var interviewers = await _db.Users.Where(u => u.Role == Role.Interviewer).ToListAsync();
            return interviewers;
        }

        public async Task<IReadOnlyList<User>> ListAllAsync()
        {
            return await _db.Users.Where(us => us.Role == Role.Interviewer).ToListAsync();
        }

        public async Task<User> LoginAsync(User user)
        {
            var result = await  _db.Users.FirstOrDefaultAsync(ur => ur.UserName == user.UserName && ur.PasswordHash == user.PasswordHash);
            if(result == null)
            {
                return null;
            }
            return result;
        }

        public async Task UpdateAsync(User entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
