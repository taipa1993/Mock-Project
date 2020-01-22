using RMT.ApplicationCore.BusinessObject;
using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Interfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task <User> LoginAsync(User user);
        Task<IReadOnlyList<User>> GetAllAsyncPaging(Page page, UserFilter user);
        Task<IReadOnlyList<User>> Interviewers();
    }
}
