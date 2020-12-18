using System;
using PARTIEL.RAEL.CALITRO.API.Core.CSV;

namespace PARTIEL.RAEL.CALITRO.API.Models.MusicDto
{
    public record MusicReadDto
    {
        [CSV(1)]
        public int Id { get; init; }
        [CSV(2)]
        public string Title { get; init; }
        [CSV(3)]
        public string Url { get; init; }

        [CSV(4)]
        public int? ArtistId { get; init; }
    }
}
