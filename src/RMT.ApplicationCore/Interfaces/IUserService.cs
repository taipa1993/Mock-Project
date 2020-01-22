using RMT.ApplicationCore.BusinessObject;
using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Interfaces
{
    public interface IUserService
    {
        Task<User> LoginAsync(User user);
        Task<User> AddAsync(User user);
        Task DeleteAsync(int id);
        Task UpdateAsync(User user);
        Task<IReadOnlyList<User>> Users();
        Task<IReadOnlyList<User>> ListAllAsyncPaging(Page page, UserFilter user);
        Task<User> GetByIdAsync(int id);
        Task<IReadOnlyList<User>> Interviewers();
    }
}
