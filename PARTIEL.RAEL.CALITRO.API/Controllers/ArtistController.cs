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

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistReadDto>> Get(int id)
        {
            var artistReadDto = await _artistService.Get(id);
            return artistReadDto is null ? NotFound() : Ok(artistReadDto);
        }

        [HttpPost]
        public async Task<ActionResult<ArtistReadDto>> Post(ArtistWriteDto artistWriteDto)
        {
            if (artistWriteDto is null) return BadRequest("Error decoding your body");
            var artistReadDto = await _artistService.Post(artistWriteDto);
            return CreatedAtAction("Get", new { id = artistReadDto.Id }, artistReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ArtistUpdateDto artistUpdateDto)
        {
            if (id != artistUpdateDto.Id)
            {
                return BadRequest();
            }


            var result = await _artistService.Put(artistUpdateDto);
            return (result == -1) ? NotFound() : NoContent();
        }

        [HttpPut("{id}/addMusics")]
        public async Task<ActionResult> AddMusics(int id, [FromBody] ArtistAddMusicsDto artistAddMusicsDto)
        {
            if (id != artistAddMusicsDto.Id)
            {
                return BadRequest();
            }


            var result = await _artistService.Put(artistAddMusicsDto);
            switch (result)
            {
                case -1:
                    return NotFound("Artist not found");
                case 0:
                    return NotFound("At least one music is not found");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _artistService.Delete(id);
            return (result == -1) ? NotFound() : NoContent();
        }
    }
}