using System;
using AutoMapper;

namespace PARTIEL.RAEL.CALITRO.API.Services.DtoServices
{
    public class DtoService
    {
        protected readonly IMapper _mapper;

        public DtoService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
