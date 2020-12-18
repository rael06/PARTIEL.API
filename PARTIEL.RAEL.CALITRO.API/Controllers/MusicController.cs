using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARTIEL.RAEL.CALITRO.API.Models.MusicDto;
using PARTIEL.RAEL.CALITRO.API.Services.DtoServices.MusicService;

namespace PARTIEL.RAEL.CALITRO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet]
        public async Task<ICollection<MusicReadDto>> GetAll() => await _musicService.GetAll();

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicReadDto>> Get(int id)
        {
            var musicReadDto = await _musicService.Get(id);
            return musicReadDto is null ? NotFound() : Ok(musicReadDto);
        }

        [HttpPost]
        public async Task<ActionResult<MusicReadDto>> Post(MusicWriteDto musicWriteDto)
        {
            if (musicWriteDto is null) return BadRequest("Error decoding your body");
            var musicReadDto = await _musicService.Post(musicWriteDto);
            return musicReadDto is null ? NotFound("Artist not found") : CreatedAtAction("Get", new { id = musicReadDto.Id }, musicReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] MusicUpdateDto musicUpdateDto)
        {
            if (id != musicUpdateDto.Id)
            {
                return BadRequest();
            }


            var result = await _musicService.Put(musicUpdateDto);

            switch(result){
                case -1:
                    return NotFound("Music not found");
                case 0:
                    return NotFound("Artist not found");
                default:
                    return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _musicService.Delete(id);
            return (result == -1) ? NotFound() : NoContent();
        }
    }
}