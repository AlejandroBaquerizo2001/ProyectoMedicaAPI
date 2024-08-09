using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoMedica.Entidades;
using ProyectoMedica.Repositorio;

namespace ApiproyectoMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdquiridoController : ControllerBase
    {
        private readonly IRepositorioAdquirido _repositorioAdquirido;

        public AdquiridoController(IRepositorioAdquirido repositorioAdquirido)
        {
            _repositorioAdquirido = repositorioAdquirido;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioAdquirido.ObtenerTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var adquirido = await _repositorioAdquirido.ObtenerPorID(id);
                return Ok(adquirido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(Adquirido adquirido)
        {
            try
            {
                var id = await _repositorioAdquirido.Crear(adquirido);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Adquirido adquirido)
        {
            try
            {

                await _repositorioAdquirido.ModificarAdquirido(adquirido);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositorioAdquirido.EliminarAdquirido(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
