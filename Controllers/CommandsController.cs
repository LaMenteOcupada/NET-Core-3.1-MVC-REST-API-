using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        //Constructor para la Inyección de dependencias
        public CommandsController(ICommanderRepo repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //Solo para pruebas -> private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        //GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null){
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
            
        }
        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto); //recuperamos el modelo mapeando del commandCreateDto a Command
            _repository.CreateCommand(commandModel); // pasamos el modelo recuperado al repositorio
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);//mapeamos del commandmodel a CommandReadDto(para devolver un dto específico)

            return CreatedAtRoute(nameof(GetCommandById),new{Id = commandReadDto.Id},commandReadDto);
            //return Ok(commandReadDto);
        }

        //PUT api/commnads/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            //comprobamos si el recurso existe o no
            var commandModelFromRepo = _repository.GetCommandById(id);
            //comprobamos si es nulo
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            //si no es nulo, recogemos el dato pasado por parámetro y lo aplicamos sobre el del repo.
            //usaremos mapeos
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);//opcional, no haría falta,(pues el entity de arriba se encarga de hacerlo) pero es buena práctica

            _repository.SaveChanges();

            return NoContent();

        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            //comprobamos si el recurso existe o no
            var commandModelFromRepo = _repository.GetCommandById(id);
            //comprobamos si es nulo
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            //generamos un nuevo command
            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);//crea un nuevo commandupdatedto con el contenido del repositorio y lo pone en commandpatch
            //le aplicamos el patch
            patchDoc.ApplyTo(commandToPatch,ModelState);//Modelstate es necesario para comprobar que las validaciones están ok
            //validaciones
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch,commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);//opcional, no haría falta,(pues el entity de arriba se encarga de hacerlo) pero es buena práctica

            _repository.SaveChanges();

            return NoContent(); 

        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]

        public ActionResult DeeleteCommand(int id)
        {
            //comprobamos si el recurso existe o no
            var commandModelFromRepo = _repository.GetCommandById(id);
            //comprobamos si es nulo
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }


    }
}