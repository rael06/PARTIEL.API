using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PARTIEL.RAEL.CALITRO.API.DATA.Models;
using PARTIEL.RAEL.CALITRO.API.DATA.Repositories.ArtistRepository;
using PARTIEL.RAEL.CALITRO.API.Models.ArtistDto;

namespace PARTIEL.RAEL.CALITRO.API.Services.DtoServices.ArtistService
{
    public class ArtistService : DtoService, IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IMapper mapper, IArtistRepository artistRepository) : base(mapper)
        {
            _artistRepository = artistRepository;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistReadDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ArtistReadDto>> GetAll()
        {
            var artists = await _artistRepository.GetAll();
            return _mapper.Map<List<ArtistReadDto>>(artists);
        }

        public async Task<ArtistReadDto> Post(ArtistWriteDto artistWriteDto)
        {
            var artistDB = _mapper.Map<Artist>(artistWriteDto);
            artistDB = await _artistRepository.Post(artistDB);
            return _mapper.Map<ArtistReadDto>(artistDB);
        }

        public Task<int> Put(ArtistUpdateDto artistUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
