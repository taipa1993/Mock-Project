using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMT.ApplicationCore.BusinessObject;
using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using RMT.ApplicationCore.Services;
using RMT.WebAPI.Helper;
using RMT.WebAPI.RequestObject;

namespace RMT.WebAPI.Controllers
{

    public class UserController : MrtBaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (user.PasswordHash == null || user.UserName == null)
            {
                return BadRequest();
            }
            user.PasswordHash = user.PasswordHash.ToHashString();
            User result = await _userService.LoginAsync(user);
            if (result != null)
            {
                string token = result.CreateTokenByUser();
                return Ok(String.Format("{0}---{1}---{2}", result.FullName, result.UserName,token));
            }
            
            return NotFound();
        }

        [Authorize(Roles = Role.Admin + "," + Role.HR)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (!user.UserName.IsMailFormat())
            {
                return BadRequest();
            }
            string plainPassword = user.PasswordHash;
            user.PasswordHash = user.PasswordHash.ToHashString();
            user.CreateAt = DateTime.Now;
            User result = await _userService.AddAsync(user);
            if (result != null)
            {
                string subject = "[No-reply][RMT] Your account is created.";
                string body = "Username: <strong>" + user.UserName + "</strong><br> Password: <strong>" + plainPassword + "</strong>";
                SmtpMail.Send(user.UserName, subject, body);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }

        [Authorize(Roles = Role.Admin + "," + Role.HR)]
        [HttpPost]
        public async Task<IActionResult> Users([FromBody] UserRequestObject req)
        {
            UserFilter userFilter = _mapper.Map<UserRequestObject, UserFilter>(req);
            Page page = _mapper.Map<UserRequestObject, Page>(req);
            var result = await _userService.ListAllAsyncPaging(page, userFilter);
            return Ok(result);
        }

        [Authorize(Roles = Role.Admin + "," + Role.HR)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Users(int id)
        {
            User user = await _userService.GetByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [Authorize(Roles = Role.Admin + "," + Role.HR)]
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userService.UpdateAsync(user);
            return Ok();
        }
        //[Authorize(Roles = Role.Admin + "," + Role.HR)]
        [HttpGet]
        public async Task<IActionResult> Interviewers()
        {
            var interviewers = await _userService.Interviewers();
            return Ok(interviewers);
        }
    }
}