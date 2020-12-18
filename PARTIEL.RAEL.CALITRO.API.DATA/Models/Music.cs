using System;
namespace PARTIEL.RAEL.CALITRO.API.DATA.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public int? ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
