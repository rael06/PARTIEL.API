using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PARTIEL.RAEL.CALITRO.API.DATA.Models;

namespace PARTIEL.RAEL.CALITRO.API.DATA.Repositories.MusicRepository
{
    public interface IMusicRepository
    {
        Task<ICollection<Music>> GetAll();
        Task<Music> Get(int id);
        Task<Music> Post(Music music);
        Task<int> Put(Music music);
        Task<int> Delete(int id);
    }
}
