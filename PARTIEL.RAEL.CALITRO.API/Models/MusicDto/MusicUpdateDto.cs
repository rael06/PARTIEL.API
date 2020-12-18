﻿using System;
using PARTIEL.RAEL.CALITRO.API.Core.CSV;

namespace PARTIEL.RAEL.CALITRO.API.Models.MusicDto
{
    public record MusicUpdateDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Url { get; init; }

        public int ArtistId { get; init; }
    }
}
