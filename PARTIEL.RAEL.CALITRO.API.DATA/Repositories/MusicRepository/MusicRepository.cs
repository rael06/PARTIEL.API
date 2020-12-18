﻿using System;
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

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Music> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Music>> GetAll() => await _context.Musics.ToListAsync();

        public async Task<Music> Post(Music music)
        {
            _context.Musics.Add(music);
            await _context.SaveChangesAsync();
            return music;
        }

        public Task<int> Put(Music music)
        {
            throw new NotImplementedException();
        }
    }
}
