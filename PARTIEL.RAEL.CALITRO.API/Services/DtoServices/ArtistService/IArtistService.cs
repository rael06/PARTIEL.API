using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PARTIEL.RAEL.CALITRO.API.Models.ArtistDto;

namespace PARTIEL.RAEL.CALITRO.API.Services.DtoServices.ArtistService
{
    public interface IArtistService
    {
        Task<ICollection<ArtistReadDto>> GetAll();
        Task<ArtistReadDto> Get(int id);
        Task<ArtistReadDto> Post(ArtistWriteDto artistWriteDto);
        Task<int> Put(ArtistUpdateDto artistUpdateDto);
        Task<int> Delete(int id);
    }
}
