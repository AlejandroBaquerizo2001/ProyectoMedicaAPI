using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoMedica.Entidades;
using ProyectoMedica.Repositorio;

namespace ApiproyectoMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {
        private readonly IRepositorioHistorial _repositorioHistorial;

        public HistorialController(IRepositorioHistorial repositorioHistorial)
        {
            _repositorioHistorial = repositorioHistorial;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioHistorial.ObtenerTodos();
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
                var historial = await _repositorioHistorial.ObtenerPorID(id);
                return Ok(historial);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Historial historial)
        {
            try
            {
                var id = await _repositorioHistorial.Crear(historial);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Historial historial)
        {
            try
            {

                await _repositorioHistorial.ModificarHistorial(historial);
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
                await _repositorioHistorial.EliminarHistorial(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
