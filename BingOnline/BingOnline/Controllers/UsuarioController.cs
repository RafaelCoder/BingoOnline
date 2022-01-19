using AutoMapper;
using BingOnline.Dtos;
using BingOnline.Persistencia.Modelo;
using BingOnline.Persistencia.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BingOnline.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public IMapper _mapper { get; set; }
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var usuarios = await _usuarioRepositorio.ObterTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}", Name = "UsuarioDetails")]
        public async Task<IActionResult> Details(Guid id)
        {
            Usuario usuario = await _usuarioRepositorio.Obter(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] CreateUsuarioDto usuario)
        {
            try
            {
                if(!(await _usuarioRepositorio.ObterPorNome(usuario.Nome) is null))
                    return StatusCode(409, "Já existe um usuário com este nome");


                Usuario newUsuario = _mapper.Map<Usuario>(usuario);
                await _usuarioRepositorio.Adicionar(newUsuario);

                var newUsuarioDTO = _mapper.Map<UsuarioDto>(newUsuario);
                return CreatedAtRoute("Details", new { Id = newUsuario.Id }, newUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(Guid id, [FromBody] UpdateUsuarioDto usuario)
        {
            try
            {
                var usuarioExistente = await _usuarioRepositorio.Obter(id);
                if (usuarioExistente is null)
                    return NotFound();

                usuarioExistente = _mapper.Map<Usuario>(usuario);
                usuarioExistente.Id = id;

                await _usuarioRepositorio.Atualizar(usuarioExistente);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            try
            {
                var usuarioExistente = await _usuarioRepositorio.Obter(id);
                if (usuarioExistente is null)
                    return NotFound();

                await _usuarioRepositorio.Deletar(usuarioExistente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Houve um erro interno bla bla bla");
            }
        }

    }
}
