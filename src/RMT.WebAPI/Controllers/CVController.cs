using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
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
    public class CVController : MrtBaseController
    {
        private readonly ICVService _cv;
        private readonly IMapper _mapper;
        public CVController(ICVService cv, IMapper mapper)
        {
            this._cv = cv;
            this._mapper = mapper;
        }

        [Authorize(Roles = Role.Admin + "," + Role.HR)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CV cv)
        {
            var result = await _cv.AddAsync(cv);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [Authorize(Roles = Role.Admin + "," + Role.HR)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CV cV)
        {
            //if (cV.Status.IsStatus())
            //{
            //    return UnprocessableEntity();
            //}
            await _cv.UpdateAsync(cV);
            return Ok();
        }

        [Authorize(Roles = Role.Admin + "," + Role.HR + "," + Role.Interviewer)]
        [HttpPost]
        public async Task<IActionResult> CVs([FromBody] CVRequestObject req)
        {
            if (req.PageSize <= 0 || req.CurrentPage <= 0)
            {
                return BadRequest();
            }
            CVFilter cvfilter = _mapper.Map<CVRequestObject, CVFilter>(req);
            Page page = _mapper.Map<CVRequestObject, Page>(req);
            var result = await _cv.GetListAsyncPaging(page, cvfilter);

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
            {
                return Unauthorized();
            }
            IEnumerable<Claim> claim = identity.Claims;
            var role = claim.FirstOrDefault(cl => cl.Type == ClaimTypes.Role).ToString().Split(' ').Last();
            if (role == Role.Interviewer)
            {
                result.ToList().ForEach(c =>
                {
                    c.ToHideSalary();
                });
            }
            return Ok(result.OrderByDescending(c => c.UpdateAt));
        }

        [Authorize(Roles = Role.Admin + "," + Role.HR + "," + Role.Interviewer)]
        [HttpGet("{id}")]
        public async Task<IActionResult> CVs(int id)
        {
            CV cv = await _cv.GetDetailAsync(id);
            if (cv == null)
            {
                return NotFound();
            }

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
            {
                return Unauthorized();
            }
            IEnumerable<Claim> claim = identity.Claims;
            var role = claim.FirstOrDefault(cl => cl.Type == ClaimTypes.Role).ToString().Split(' ').Last();
            if (role == Role.Interviewer)
            {
                return Ok(cv.ToHideSalary());
            }

            return Ok(cv);
        }
        [HttpGet]
        public async Task<IActionResult> CVTotalRow()
        {
            int result = await _cv.CVTotalRows();
            return Ok(result);
        }

        [Authorize(Roles = Role.Admin + "," + Role.HR)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCv(int id)
        {
            CV cv = await _cv.GetDetailAsync(id);
            cv.DeleteCVFile();
            await _cv.DeleteAsync(id);
            return Ok();
        }
    }
}