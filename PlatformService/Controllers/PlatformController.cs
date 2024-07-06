using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;
        public PlatformController(IPlatformRepo repo, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _repo = repo;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
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
        public async Task<IActionResult> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platform = _mapper.Map<Platform>(platformCreateDto);
            _repo.CeatePlatform(platform);
            _repo.SaveChanges();
            var platformReadDto = _mapper.Map<PlatformReadDto>(platform);
            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Occured");
            }
            return Ok("Done");
        }
    }
}