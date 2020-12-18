using System;
using PARTIEL.RAEL.CALITRO.API.Models.MusicDto;

namespace PARTIEL.RAEL.CALITRO.API.Models.ArtistDto
{
    public record ArtistAddMusicsDto
    {
        public int Id { get; init; }
        public MusicToAddDto[] Musics { get; init; }
    }
}
