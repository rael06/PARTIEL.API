using System;
using Microsoft.EntityFrameworkCore;

namespace PARTIEL.RAEL.CALITRO.API.DATA
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
