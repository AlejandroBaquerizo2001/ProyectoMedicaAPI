using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoMedica.Entidades;
using ProyectoMedica.Repositorio;

namespace ApiproyectoMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IRepositorioServicios _repositorioServicios;

        public ServiciosController(IRepositorioServicios repositorioServicios)
        {
            _repositorioServicios = repositorioServicios;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioServicios.ObtenerTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(Servicios servicios)
        {
            try
            {
                var id = await _repositorioServicios.Crear(servicios);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositorioServicios.EliminarServicios(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Servicios servicios)
        {
            if (id != servicios.Id)
            {
                return BadRequest("El ID del producto no coincide.");
            }

            var productoExitente = await _repositorioServicios.ObtenerPorID(id);
            if (productoExitente == null)
            {
                return NotFound();
            }

            productoExitente.Nombre = servicios.Nombre;
            productoExitente.Area = servicios.Area;
            productoExitente.Oferta = servicios.Oferta;
            productoExitente.Valor = servicios.Valor;

            await _repositorioServicios.ModificarServicios(productoExitente);

            return NoContent();
        }
    }
}
