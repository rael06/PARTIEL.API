using System;
using AutoMapper;
using PARTIEL.RAEL.CALITRO.API.DATA.Models;
using PARTIEL.RAEL.CALITRO.API.Models.MusicDto;

namespace PARTIEL.RAEL.CALITRO.API.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Music, MusicReadDto>().ReverseMap();
        }
    }
}
