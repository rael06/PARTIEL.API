using System;
using System.Collections.Generic;
using PARTIEL.RAEL.CALITRO.API.Core.CSV;
using PARTIEL.RAEL.CALITRO.API.Models.MusicDto;

namespace PARTIEL.RAEL.CALITRO.API.Models.ArtistDto
{
    public record ArtistReadDto
    {
        [CSV(1)]
        public int Id { get; init; }
        [CSV(2)]
        public string Name { get; init; }
        [CSV(3)]
        public string Image { get; init; }

        public List<MusicReadDto> Musics { get; init; }
    }
}
