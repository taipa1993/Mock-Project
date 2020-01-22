using RMT.ApplicationCore.BusinessObject;
using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMT.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<User> AddAsync(User user)
        {
            
            User result = await _userRepository.AddAsync(user);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task DeleteAsync(int id)
        {
            User userDelete = await _userRepository.GetByIdAsync(id);
            if (userDelete != null)
            {
                await _userRepository.DeleteAsync(userDelete);
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<IReadOnlyList<User>> Interviewers()
        {
            IReadOnlyList<User> users = await _userRepository.Interviewers();
            return users;
        }

        public async Task<IReadOnlyList<User>> ListAllAsyncPaging(Page page, UserFilter user)
        {
            IReadOnlyList<User> users = await _userRepository.GetAllAsyncPaging(page, user);
            return users;
        }

        public async Task<User> LoginAsync(User user)
        {
            return await _userRepository.LoginAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task<IReadOnlyList<User>> Users()
        {
            return await _userRepository.ListAllAsync();
        }
    }
}
