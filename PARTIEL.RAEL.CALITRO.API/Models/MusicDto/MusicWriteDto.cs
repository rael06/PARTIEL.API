using System;
namespace PARTIEL.RAEL.CALITRO.API.Models.MusicDto
{
    public record MusicWriteDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Url { get; init; }

        public int ArtistId { get; init; }
    }
}
