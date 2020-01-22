using AutoMapper;
using RMT.ApplicationCore.BusinessObject;
using RMT.WebAPI.RequestObject;
using RMT.ApplicationCore.Entities;
using RMT.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMT.WebAPI.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CVRequestObject, CVFilter>();
            CreateMap<CVRequestObject, Page>();

            CreateMap<UserRequestObject, UserFilter>();
            CreateMap<UserRequestObject, Page>();

            CreateMap<Round, Test>();
            CreateMap<Test, Round>();

            CreateMap<Round, Interview>();
            CreateMap<Interview, Round>();

            CreateMap<Round, Offer>();
            CreateMap<Offer, Round>();

            CreateMap<Round, RoundView>();
            CreateMap<RoundView, Round>();
        }
    }
}
