using System;
using AutoMapper;
using PARTIEL.RAEL.CALITRO.API.DATA.Models;
using PARTIEL.RAEL.CALITRO.API.Models.ArtistDto;
using PARTIEL.RAEL.CALITRO.API.Models.MusicDto;

namespace PARTIEL.RAEL.CALITRO.API.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Artist, ArtistReadDto>().ReverseMap();
            CreateMap<Artist, ArtistWriteDto>().ReverseMap();
            CreateMap<Artist, ArtistUpdateDto>().ReverseMap();
            CreateMap<Artist, ArtistAddMusicsDto>().ReverseMap();

            CreateMap<Music, MusicReadDto>().ReverseMap();
            CreateMap<Music, MusicWriteDto>().ReverseMap().ForMember(dest => dest.ArtistId, opt => opt.AddTransform(x => x == 0 ? null : x));
            CreateMap<Music, MusicUpdateDto>().ReverseMap().ForMember(dest => dest.ArtistId, opt => opt.AddTransform(x => x == 0 ? null : x));
            CreateMap<Music, MusicToAddDto>().ReverseMap();
        }
    }
}
