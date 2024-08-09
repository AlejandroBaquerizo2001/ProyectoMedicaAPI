using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoMedica.Entidades;
using ProyectoMedica.Repositorio;

namespace ApiproyectoMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IRepositorioProducto _repositorioProducto;

        public ProductoController(IRepositorioProducto repositorioProducto)
        {
            _repositorioProducto = repositorioProducto;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioProducto.ObtenerTodos();
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
                var productos = await _repositorioProducto.ObtenerPorID(id);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(Producto productos)
        {
            try
            {
                var id = await _repositorioProducto.Crear(productos);
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
                await _repositorioProducto.EliminarProducto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Producto productos)
        {
            if (id != productos.Id)
            {
                return BadRequest("El ID del producto no coincide.");
            }

            var productoExitente = await _repositorioProducto.ObtenerPorID(id);
            if (productoExitente == null)
            {
                return NotFound();
            }

            productoExitente.Nombre = productos.Nombre;
            productoExitente.TipoProducto = productos.TipoProducto;
            productoExitente.Cantidad = productos.Cantidad;
            productoExitente.FechaIngreso = productos.FechaIngreso;

            await _repositorioProducto.ModificarProducto(productoExitente);

            return NoContent();
        }
    }
}
