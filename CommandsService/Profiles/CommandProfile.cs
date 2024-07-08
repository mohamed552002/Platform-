using AutoMapper;
using CommandsService.Dtos;
using CommandsService.Models;

namespace CommandsService.Profiles
{
    class CommandProfile : Profile
    {
        public CommandProfile()
        {
            // Command
            CreateMap<Command,CommandReadDto>();
            CreateMap<CommandCreateDto,Command>();
            // Platform
            CreateMap<Platform,PlatformReadDto>();
        }
    }
}