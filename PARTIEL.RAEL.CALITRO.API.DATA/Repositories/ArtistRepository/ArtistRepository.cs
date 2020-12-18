using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ICollection<Artist>> GetAll() => await _context.Artists.Include(x => x.Musics).ToListAsync();

        public async Task<int> Delete(int id)
        {
            var artist = await Get(id);
            if (artist is null)
                return -1;
            _context.Artists.Remove(artist);
            return await _context.SaveChangesAsync();
        }

        public async Task<Artist> Get(int id)
        {
            return await _context.Artists.Include(x => x.Musics).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Artist> Post(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<int> Put(Artist artist)
        {
            _context.Entry(artist).State = EntityState.Modified;

            int result;
            try
            {
                result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ArtistExistsAsync(artist.Id))
                {
                    result = -1;
                }
                else
                {
                    throw;
                }
            }
            return result;
        }

        public async Task<int> AddMusics(Artist artist)
        {
            var musics = new List<Music>();
            foreach (var music in artist.Musics)
            {
                if (await MusicExistsAsync(music.Id)) musics.Add(music);
            }

            var artistDB = await Get(artist.Id);

            if (artistDB is null) return -1;
            if (musics.Count == 0) return 0;

            artistDB.Musics = musics;
            return await Put(artistDB);
        }

        private async Task<bool> ArtistExistsAsync(int id)
        {
            return await _context.Artists.AnyAsync(x => x.Id == id);
        }

        private async Task<bool> MusicExistsAsync(int id)
        {
            return await _context.Musics.AnyAsync(x => x.Id == id);
        }

    }
}
