using AutoMapper;
using BingOnline.Dtos;
using BingOnline.Persistencia.Modelo;
using BingOnline.Persistencia.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BingOnline.Controllers
{
    [ApiController]
    [Route("partidas/{idPartida}/participantes")]
    public class ParticipanteController : ControllerBase
    {
        private readonly IPartidaRepositorio _partidaRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public IMapper _mapper { get; set; }
        public ParticipanteController(IPartidaRepositorio partidaRepositorio, IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _partidaRepositorio = partidaRepositorio;
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("teste")]
        public string Teste(Guid idPartida)
        {//ActionResult<Cartela>
            Cartela cartela = new Cartela();
            cartela.GerarNumeros();
            cartela.OrdenarNumeros();

            string res = $"Partida: {idPartida} \n";
            int i = 1;
            foreach (var num in cartela.Numeros) {
                res += num.Codigo.ToString("00");
                if (i++ >= 5)
                {
                    res += "\n";
                    i = 1;
                } else
                    res += " ";
            }
            return res;
        }

        [HttpGet]
        public async Task<IActionResult> Listar(Guid idPartida)
        {
            Partida partida = await _partidaRepositorio.Obter(idPartida);
            if (partida == null)
                return NotFound();

            var participantes = partida.Participantes;

            var participantesDTO = _mapper.Map<List<ParticipanteDto>>(participantes);

            return Ok(participantes);
        }

        [HttpGet("{id}", Name = "ParticipanteDetails")]
        public async Task<IActionResult> ParticipanteDetails(Guid idPartida, int id) {
            Partida partida = await _partidaRepositorio.Obter(idPartida);
            if (partida == null)
                return NotFound();
            Participante part = null;
            var participantes = partida.Participantes;
            foreach (Participante p in participantes) {
                if (p.Id == id)
                {
                    part = p;
                    break;
                }
            }
            if (part == null)
                return NotFound();
            var participanteDto = _mapper.Map<ParticipanteDto>(part);
            return Ok(participanteDto);
        }

        [HttpPost]
        public async Task<IActionResult> NovoParticipante(Guid idPartida, [FromBody] CreateParticipanteDto participante) {
            try
            {
                Usuario usuario = await _usuarioRepositorio.Obter(participante.IdUsuario);

                if (usuario == null)
                    return StatusCode(409, "Usuário não encontrado");//verificar retorno correto

                Partida partida = await _partidaRepositorio.Obter(idPartida);
                if (partida == null)
                    return NotFound();

                var participantes = partida.Participantes;

                Participante newParticipante = new Participante();
                newParticipante.Id = participantes.Count +1; // mudar pra Guid  teste
                newParticipante.Usuario = usuario;
                newParticipante.Cartela = new Cartela();
                newParticipante.Cartela.GerarNumeros();
                newParticipante.Cartela.OrdenarNumeros();

                partida.Participantes.Add(newParticipante);
                await _partidaRepositorio.Atualizar(partida);

                var partidaDTO = _mapper.Map<PartidaDto>(partida);
                return CreatedAtRoute("PartidaDetails", new { Id = partidaDTO.Id }, partidaDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
