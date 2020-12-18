using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PARTIEL.RAEL.CALITRO.API.Models.MusicDto;

namespace PARTIEL.RAEL.CALITRO.API.Services.DtoServices.MusicService
{
    public interface IMusicService
    {
        Task<ICollection<MusicReadDto>> GetAll();
    }
}
