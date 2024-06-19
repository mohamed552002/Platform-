using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPlatforms()
        {
            var platformsDto = _mapper.Map<IEnumerable<PlatformReadDto>>(_repo.GetAllPlatforms());
            return Ok(platformsDto);
        }
        [HttpGet("{id}",Name ="GetPlatformById")]
        public IActionResult GetPlatformById(int id)
        {
            var platformDto = _mapper.Map<PlatformReadDto>(_repo.GetPlatformById(id));
            return Ok(platformDto);
        }
        [HttpPost()]
        public IActionResult CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platform = _mapper.Map<Platform>(platformCreateDto);
            _repo.CeatePlatform(platform);
            _repo.SaveChanges();
            return Ok("Done");
        }
    }
}