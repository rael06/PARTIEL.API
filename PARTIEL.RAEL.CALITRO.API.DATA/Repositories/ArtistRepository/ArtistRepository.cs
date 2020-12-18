using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PARTIEL.RAEL.CALITRO.API.DATA.Models;

namespace PARTIEL.RAEL.CALITRO.API.DATA.Repositories.ArtistRepository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MyContext _context;

        public ArtistRepository(MyContext context)
        {
            _context = context;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Artist> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Artist>> GetAll() => await _context.Artists.ToListAsync();

        public async Task<Artist> Post(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public Task<int> Put(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}
