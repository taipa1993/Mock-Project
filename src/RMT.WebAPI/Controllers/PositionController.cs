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
    public class PositionController : MrtBaseController
    {
        private readonly IPositionService _poService;
        public PositionController(IPositionService positionService)
        {
            this._poService = positionService;
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin + "," + Role.HR + Role.Interviewer)]
        public async Task<IActionResult> Postions()
        {
            var result = await _poService.PositionsAsync();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin + "," + Role.HR)]
        public async Task<IActionResult> Add([FromBody] Position postion)
        {
            var postionAdd = await _poService.Add(postion);
            if (postionAdd != null)
            {
                return BadRequest();
            }
            return Ok(postionAdd);

        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _poService.DeletePosition(id);
            return Ok();
        }

        [Authorize(Roles = Role.Admin + "," + Role.HR)]
        [HttpPut]
        public async Task<IActionResult> Update(Position position)
        {
            await _poService.UpdateAsync(position);
            return Ok();
        }

    }
}