using System;
using System.Collections.Generic;

namespace PARTIEL.RAEL.CALITRO.API.DATA.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Music> Musics { get; set; }
    }
}
