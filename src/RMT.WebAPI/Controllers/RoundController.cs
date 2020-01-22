using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMT.ApplicationCore.BusinessObject;
using RMT.ApplicationCore.Constants;
using RMT.ApplicationCore.Entities;
using RMT.ApplicationCore.Interfaces;
using RMT.WebAPI.Helper;
using RMT.WebAPI.Models;

namespace RMT.WebAPI.Controllers
{
    [Authorize]
    public class RoundController : MrtBaseController
    {
        private List<Status> statuses = StatusList.Statuses();
        private readonly IRoundService _roundService;
        private readonly IUserRoundService _userRoundService;
        private readonly IMapper _mapper;
        public RoundController(IRoundService roundService, IUserRoundService userRoundService, IMapper mapper)
        {
            this._roundService = roundService;
            this._userRoundService = userRoundService;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetStatusList()
        {
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListByCvId(int id)
        {
            var result = await _roundService.ListByCvIdAsync(id);
            var roundViews = new List<RoundView>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    var roundView = await MapRoundToRoundView(item);
                    roundViews.Add(roundView);
                }
            }
            return Ok(roundViews);
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin + "," + Role.HR)]
        public async Task<IActionResult> AddRound([FromBody] RoundView roundView)
        {
            //CHECK STATUS 
            if (!CheckHelper.IsStatusExist(roundView.Status, roundView.Name))
            {
                return BadRequest();
            }

            //CHECK IF CV HAD ROUND
            var rounds = await _roundService.ListByCvIdAsync(roundView.CVId);
            if (rounds.Where(r => r.Name == roundView.Name).Count() > 0)
            {
                return BadRequest();
            }

            roundView.CreateAt = DateTime.Now;
            roundView.UpdateAt = DateTime.Now;
            Round round = _mapper.Map<RoundView, Round>(roundView);
            var result = await _roundService.AddAsync(round);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRound(int id)
        {
            var round = await _roundService.GetByIdAsync(id);
            if (round == null)
            {
                return BadRequest();
            }
            RoundView roundView = await MapRoundToRoundView(round);
            return Ok(roundView);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRound([FromBody] RoundView roundView)
        {
            Round round = new Round();
            roundView.UpdateAt = DateTime.Now;

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
            {
                return Unauthorized();
            }

            IEnumerable<Claim> claim = identity.Claims;
            var role = claim.FirstOrDefault(cl => cl.Type == ClaimTypes.Role).ToString().Split(' ').Last();
            var claimName = claim.FirstOrDefault(cl => cl.Type == ClaimTypes.Name).ToString().Split(' ').Last();
            var UserId = int.Parse(claimName);

            //Admin or HR update
            if (role == Role.Admin || role == Role.HR)
            {
                round = _mapper.Map<RoundView, Round>(roundView);

                var updateStatus = round.Status;
                var roundId = round.Id;
                var roundInDatabase = await _roundService.GetByIdAsync(roundId);
                var CurentStatus = roundInDatabase.Status;

                if (round.Name != roundInDatabase.Name)
                {
                    return BadRequest();
                }

                if (!CheckHelper.IsStatusChangeOK(updateStatus, CurentStatus, round.Name))
                {
                    return BadRequest();
                }

                if (round.Name == RoundName.Interview)
                {
                    await _userRoundService.DeleteByRoundIdAsync(roundId);

                    if (roundView.InterviewerIds != null)
                    {
                        var interviewerIds = roundView.InterviewerIds;
                        var userRounds = new List<UserRound>();
                        foreach (var item in interviewerIds)
                        {
                            userRounds.Add(new UserRound { UserId = item, RoundId = roundId });
                        }
                        await _userRoundService.AddListAsync(userRounds);
                    }
                }
            }

            // Interviewer update FeedBackLink
            if ((role == Role.Interviewer) && (roundView.Name == RoundName.Interview))
            {
                if (roundView.InterviewerIds.Where(i => i == UserId) != null)
                {
                    round = await _roundService.GetByIdAsync(roundView.Id);
                    round.FeedBackLink = roundView.FeedBackLink;
                }
            }

            var result = await _roundService.UpdateAsync(round);
            if (result != null)
            {
                return Ok(roundView);
            }
            return BadRequest();
        }

        private async Task<RoundView> MapRoundToRoundView(Round round)
        {
            RoundView roundView = _mapper.Map<Round, RoundView>(round);

            if (round.UserRounds != null)
            {
                var userRounds = await _userRoundService.GetListByRoundIdAsync(round.Id);
                List<int> interviewerIds = new List<int>();
                foreach (var item in userRounds)
                {
                    interviewerIds.Add(item.UserId);
                }
                roundView.InterviewerIds = interviewerIds;
            }
            return roundView;
        }
    }
}