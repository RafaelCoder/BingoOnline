using AutoMapper;
using BingOnline.Dtos;
using BingOnline.Persistencia.Modelo;
using BingOnline.Persistencia.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BingOnline.Controllers
{
    [ApiController]
    [Route("partidas")]
    public class PartidaController : ControllerBase
    {
        private readonly IPartidaRepositorio _partidaRepositorio;
        public IMapper _mapper { get; set; }
        public PartidaController(IPartidaRepositorio partidaRepositorio, IMapper mapper)
        {
            _partidaRepositorio = partidaRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var partidas = await _partidaRepositorio.ObterTodos();
            return Ok(partidas);
        }

        [HttpGet("{id}", Name = "PartidaDetails")]
        public async Task<IActionResult> Details(Guid id)
        {
            Partida partida = await _partidaRepositorio.Obter(id);
            if (partida == null)
                return NotFound();
            var newPartidaDTO = _mapper.Map<PartidaDto>(partida);
            return Ok(newPartidaDTO);
        }

        [HttpPost]
        public async Task<IActionResult> NovaPartida([FromBody] CreatePartidaDto partida)
        {
            try
            {
                Partida newPartida = _mapper.Map<Partida>(partida);
                await _partidaRepositorio.Adicionar(newPartida);

                var newPartidaDTO = _mapper.Map<PartidaDto>(newPartida);
                return CreatedAtRoute("PartidaDetails", new { Id = newPartidaDTO.Id }, newPartidaDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            try
            {
                var partidaExistente = await _partidaRepositorio.Obter(id);
                if (partidaExistente is null)
                    return NotFound();

                await _partidaRepositorio.Deletar(partidaExistente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
