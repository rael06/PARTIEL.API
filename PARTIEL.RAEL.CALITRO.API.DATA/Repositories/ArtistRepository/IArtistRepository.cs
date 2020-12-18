using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PARTIEL.RAEL.CALITRO.API.DATA.Models;

namespace PARTIEL.RAEL.CALITRO.API.DATA.Repositories.ArtistRepository
{
    public interface IArtistRepository
    {
        Task<ICollection<Artist>> GetAll();
        Task<Artist> Get(int id);
        Task<Artist> Post(Artist artist);
        Task<int> Put(Artist artist);
        Task<int> Delete(int id);
    }
}
