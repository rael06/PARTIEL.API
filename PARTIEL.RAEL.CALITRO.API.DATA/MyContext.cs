using System;
using Microsoft.EntityFrameworkCore;
using PARTIEL.RAEL.CALITRO.API.DATA.Models;

namespace PARTIEL.RAEL.CALITRO.API.DATA
{
    public class MyContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Music> Musics { get; set; }

        public MyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
