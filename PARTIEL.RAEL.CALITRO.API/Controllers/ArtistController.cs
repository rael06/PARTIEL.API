using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARTIEL.RAEL.CALITRO.API.Models.ArtistDto;
using PARTIEL.RAEL.CALITRO.API.Services.DtoServices.ArtistService;

namespace PARTIEL.RAEL.CALITRO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<ICollection<ArtistReadDto>> GetAll() => await _artistService.GetAll();


        [HttpPost]
        public async Task<ActionResult<ArtistReadDto>> Post(ArtistWriteDto artistWriteDto)
        {
            if (artistWriteDto is null) return BadRequest("Error decoding your body");
            var artistReadDto = await _artistService.Post(artistWriteDto);
            return CreatedAtAction("Get", new { id = artistReadDto.Id }, artistReadDto);
        }
    }
}