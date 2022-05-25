using chapter.Interfaces;
using chapter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chapter.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _iUsuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iUsuarioRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                Usuario usuario = _iUsuarioRepository.BuscarId(id);

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPost]

        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]

        public IActionResult Alterar(int id, Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Alterar(id, usuario);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _iUsuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
