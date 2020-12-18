using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PARTIEL.RAEL.CALITRO.API.DATA.Models;
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

        public async Task<int> Delete(int id)
        {
            return await _musicRepository.Delete(id);
        }

        public async Task<MusicReadDto> Get(int id)
        {
            var musicDB = await _musicRepository.Get(id);
            return musicDB is null ? null : _mapper.Map<MusicReadDto>(musicDB);
        }

        public async Task<MusicReadDto> Post(MusicWriteDto musicWriteDto)
        {
            var musicDB = _mapper.Map<Music>(musicWriteDto);
            musicDB = await _musicRepository.Post(musicDB);
            return _mapper.Map<MusicReadDto>(musicDB);
        }

        public async Task<int> Put(MusicUpdateDto musicUpdateDto)
        {
            var musicDB = _mapper.Map<Music>(musicUpdateDto);
            return await _musicRepository.Put(musicDB);
        }
    }
}
