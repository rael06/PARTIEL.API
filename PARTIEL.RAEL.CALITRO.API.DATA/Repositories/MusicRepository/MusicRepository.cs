using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PARTIEL.RAEL.CALITRO.API.DATA.Models;

namespace PARTIEL.RAEL.CALITRO.API.DATA.Repositories.MusicRepository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly MyContext _context;

        public MusicRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Music>> GetAll() => await _context.Musics.ToListAsync();

        public async Task<int> Delete(int id)
        {
            var music = await Get(id);
            if (music is null)
                return -1;
            _context.Musics.Remove(music);
            return await _context.SaveChangesAsync();
        }

        public async Task<Music> Get(int id)
        {
            return await _context.Musics.FindAsync(id);
        }

        public async Task<Music> Post(Music music)
        {
            _context.Musics.Add(music);
            await _context.SaveChangesAsync();
            return music;
        }

        public async Task<int> Put(Music music)
        {
            _context.Entry(music).State = EntityState.Modified;

            int result;
            try
            {
                result = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = 1;
                if (ex is DbUpdateConcurrencyException || ex is DbUpdateException)
                {
                    if (!await MusicExistsAsync(music.Id))
                    {
                        result = -1;
                    }
                    else if (!await ArtistExistsAsync(music.ArtistId))
                    {
                        result = 0;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return result;
        }

        private async Task<bool> MusicExistsAsync(int id)
        {
            return await _context.Musics.AnyAsync(x => x.Id == id);
        }

        private async Task<bool> ArtistExistsAsync(int? id)
        {
            if (id is null) return false;

            return await _context.Artists.AnyAsync(x => x.Id == id);
        }
    }
}
