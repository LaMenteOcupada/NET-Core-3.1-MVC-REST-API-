using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{

    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Mapeamos Origen -> Destino
            CreateMap<Command,CommandReadDto>();
            //Mapeamos Destino -> Origen
            CreateMap<CommandCreateDto, Command>();
            //Mapeamos del updatedto al command
            CreateMap<CommandUpdateDto,Command>();
            //del command al commandupdatedto
            CreateMap<Command,CommandUpdateDto>();
        }
    }

}