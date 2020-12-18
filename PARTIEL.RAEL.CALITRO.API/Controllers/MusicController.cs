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
    }
}