using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;

namespace RMT.WebAPI.Controllers
{
    public class LevelController : MrtBaseController
    {
        private readonly ILevelService _levelService;
        public LevelController(ILevelService level)
        {
            this._levelService = level;
        }
        [Authorize(Roles = Role.Admin + "," + Role.Interviewer + "," + Role.HR)]
        [HttpGet]
        public async Task<IActionResult> Levels()
        {
            var models = await _levelService.GetListAsync();
            return Ok(models);
        }

        [Authorize(Roles = Role.Admin + "," + Role.Interviewer + "," + Role.HR)]
        [HttpPost]
        public async Task<IActionResult> Add(Level level)
        {
            var model = await _levelService.AddAsync(level);
            if (model != null)
            {
                return Ok();
            }
            return BadRequest();
        }
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _levelService.DeleteAsync(id);
            return Ok();
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(Level level)
        {
            await _levelService.UpdateAsync(level);
            return Ok();
        }
    }
}