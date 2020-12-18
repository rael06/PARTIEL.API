using System;
namespace PARTIEL.RAEL.CALITRO.API.Models.ArtistDto
{
    public record ArtistWriteDto
    {
        public string Name { get; init; }
        public string Image { get; init; }
    }
}
