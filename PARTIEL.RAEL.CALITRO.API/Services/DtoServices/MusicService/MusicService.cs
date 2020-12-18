using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PARTIEL.RAEL.CALITRO.API.DATA.Repositories.MusicRepository;
using PARTIEL.RAEL.CALITRO.API.Models.MusicDto;

namespace PARTIEL.RAEL.CALITRO.API.Services.DtoServices.MusicService
{
    public class MusicService : DtoService, IMusicService
    {
        private readonly IMusicRepository _musicRepository;

        public MusicService(IMapper mapper, IMusicRepository musicRepository) : base(mapper)
        {
            _musicRepository = musicRepository;
        }

        public async Task<ICollection<MusicReadDto>> GetAll()
        {
            var musics = await _musicRepository.GetAll();
            return _mapper.Map<List<MusicReadDto>>(musics);
        }
    }
}
