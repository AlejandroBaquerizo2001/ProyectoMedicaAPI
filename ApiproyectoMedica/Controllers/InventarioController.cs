using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoMedica.Entidades;
using ProyectoMedica.Repositorio;

namespace ApiproyectoMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IRepositorioInventario _repositorioInventario;

        public InventarioController(IRepositorioInventario repositorioInventario)
        {
            _repositorioInventario = repositorioInventario;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioInventario.ObtenerTodos();
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
                var inventario = await _repositorioInventario.ObtenerPorID(id);
                return Ok(inventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(Inventario inventario)
        {
            try
            {
                var id = await _repositorioInventario.Crear(inventario);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Inventario inventario)
        {
            try
            {

                await _repositorioInventario.ModificarInventario(inventario);
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
                await _repositorioInventario.EliminarInventario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
